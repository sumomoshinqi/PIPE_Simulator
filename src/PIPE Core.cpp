/*
This is a Y86 Pipeline simulator
*/

#include <cstdio>
#include <cstdlib>
#include <cstring>
#include <iostream>
#include <fstream>
#include <string>
using namespace std;

// Instruction identifiers
const int NOP    = 0;   // non-operation
const int HALT   = 1;   // halt
const int RRMOVL = 2;   // move - register to register
const int IRMOVL = 3;   // move - immediate number to register
const int RMMOVL = 4;   // move - register to memory
const int MRMOVL = 5;   // move - memory to register
const int OPL    = 6;   // arithmetic operation - addition, subtraction, and, xor
const int JXX    = 7;   // jump instructions
const int CALL   = 8;   // call
const int RET    = 9;   // return from a procedure
const int PUSHL  =10;   // push the value of a register into stack
const int POPL   =11;   // pop the stack-top value to a register
const int IADDL  =12;   // EXTRA: addtion of an immediate number and a register
const int LEAVE  =13;   // EXTRA: preparation for returning from a procedure

// Register identifiers
const int EAX = 0;
const int ECX = 1;
const int EDX = 2;
const int EBX = 3;
const int ESP = 4;
const int EBP = 5;
const int ESI = 6;
const int EDI = 7;
const int NONE = 8;

// default position for the NOP insctrction
const int nop_pc = 0x800;

const char h[16] = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f'};

// Register names
const string reg_name[8] = { "%eax", "%ecx", "%edx", "%ebx", "%esp", "%ebp", "%esi", "%edi" };

// Filenames
string inFile, outFile, memFile, regFile, asmFile;

// M is the memory space, storing instructions and the stack
// instr is an array to indicate wether this position is the beginning of an instruction
int M[5000], instr[5000];
// register
int R[9];
// condition registers
int ZF, SF, OF;

int start, last, cycle, ninstr;

// registers for Fetching stage
int new_F_predPC;
int F_predPC;
int f_pc, f_icode, f_ifun, f_valC, f_valP;
int need_regids, need_valC;

// registers for Decoding stage
int new_D_pc, new_D_icode, new_D_ifun, new_D_rA, new_D_rB, new_D_valC, new_D_valP;
int D_pc, D_icode, D_ifun, D_rA, D_rB, D_valC, D_valP;
int d_srcA, d_srcB, d_rvalA, d_rvalB;

// registers for Execution stage
int new_E_pc, new_E_icode, new_E_ifun, new_E_valC, new_E_srcA, new_E_valA, new_E_srcB, new_E_valB, new_E_dstE, new_E_dstM;
int E_pc, E_icode, E_ifun, E_valC, E_srcA, E_valA, E_srcB, E_valB, E_dstE, E_dstM;
int e_valE, e_Bch;
int alufun, aluA, aluB, set_cc;

// registers for Memory stage
int new_M_pc, new_M_icode, new_M_ifun, new_M_valA, new_M_dstE, new_M_valE, new_M_dstM, new_M_Bch;
int M_pc, M_icode, M_ifun, M_valA, M_dstE, M_valE, M_dstM, M_Bch;
int m_valM;
int mem_addr, mem_read, mem_write;

// registers for Write-back stage
int new_W_pc, new_W_icode, new_W_dstE, new_W_valE, new_W_dstM, new_W_valM;
int W_pc, W_icode, W_dstE, W_valE, W_dstM, W_valM;

// variables to indicate current states for each stage
// not that X_bubble and X_stall cannot be simultaneously true
int F_bubble, F_stall, D_bubble, D_stall, E_bubble, E_stall, M_bubble, M_stall, W_bubble, W_stall;

ifstream fin;
ofstream fout, rout, eout, sout;

// number in hexadecimal form
string hex(int val)
{
    string str = "0x";
    int i, a[8];
    for (i = 0; i < 8; i++, val = val >> 4)
        a[i] = (val & 15);
    str = str + h[a[7]] + h[a[6]] + h[a[5]] + h[a[4]] + h[a[3]] + h[a[2]] + h[a[1]] + h[a[0]];
    return str;
}

// number in 3-hexadecimal form : with only length of only 3 bits
string thex(int val)
{
    string str = "0x";
    int i, a[8];
    for (i = 0; i < 8; i++, val = val >> 4)
        a[i] = (val & 15);
    str = str + h[a[2]] + h[a[1]] + h[a[0]];
    return str;
}

// number in short-hexadecimal form : with as least bits as possible
string shex(int val)
{
    string str = "0x";
    int i, a[8], j = 7;
    for (i = 0; i < 8; i++, val = val >> 4)
        a[i] = (val & 15);

    while (a[j] == 0 && j >= 0) j--;
    if (j < 0) j = 0;
    while (j >= 0)
    {
        str = str + h[a[j]];
        j--;
    }

    return str;
}

// boolean
string boo(int x)
{
    if (x == 0) return "false";
    if (x == 1) return "true";
}


// extracting valC; little endian
int valC(int addr, int need_regids, int need_valC)
{
    if (!need_valC) return 0;
    int i, a, b, c, d, e;
    if (need_regids) i = 4;
    else             i = 2;

    addr = addr * 2;
    a = (M[addr+i+0] << 4) + M[addr+i+1];
    b = (M[addr+i+2] << 4) + M[addr+i+3];
    c = (M[addr+i+4] << 4) + M[addr+i+5];
    d = (M[addr+i+6] << 4) + M[addr+i+7];

    e = (d << 24) + (c << 16) + (b << 8) + a;
    return e;
}
// extracting a number stored in memory; little endian
int decimal(int addr)
{
    int i, a, b, c, d, e;

    i = 0;
    addr = addr * 2;
    a = (M[addr+i+0] << 4) + M[addr+i+1];
    b = (M[addr+i+2] << 4) + M[addr+i+3];
    c = (M[addr+i+4] << 4) + M[addr+i+5];
    d = (M[addr+i+6] << 4) + M[addr+i+7];

    e = (d << 24) + (c << 16) + (b << 8) + a;
    return e;
}

// writing number at a give address
void insert(int addr, int val)
{
    int i, a[8];
    for (i = 0; i < 8; i++, val = val >> 4)
        a[i] = (val & 15);

    addr = addr * 2;
    M[addr+0] = a[1]; M[addr+1] = a[0];
    M[addr+2] = a[3]; M[addr+3] = a[2];
    M[addr+4] = a[5]; M[addr+5] = a[4];
    M[addr+6] = a[7]; M[addr+7] = a[6];
}

//computation & set CC
int comp(int fun, int A, int B)
{
    int C;
    if (fun == 0) C = A + B;
    if (fun == 1)
    {
        A = -A;
        C = A + B;
    }
    if (fun == 2) C = A&B;
    if (fun == 3) C = A^B;

    if (set_cc)
    {
        ZF = (C == 0);
        SF = (C  < 0);
        if ( ((fun == 0) || (fun == 1)) && ((A > 0 && B > 0 && C <= 0) || (A < 0 && B < 0 && C >= 0)) )
            OF = 1;
        else
            OF = 0;
    }

    return (int)C;
}

// jump conditions
int Cond(int ZF, int SF, int OF, int fun)
{
    int C;
    if (fun == 0)
        C = 1;
    if (fun == 1)
        C = (SF ^ OF) | ZF;
    if (fun == 2)
        C = SF ^ OF;
    if (fun == 3)
        C = ZF;
    if (fun == 4)
        C = 1 - ZF;
    if (fun == 5)
        C = 1 - (SF ^ OF);
    if (fun == 6)
        C = (1 - (SF ^ OF)) & (1 - ZF);
    return C;
}


// FETCH logic
void fetch()
{
    if ( (M_icode == JXX) && (!M_Bch) )
        f_pc = M_valA;
    else if (W_icode == RET)
        f_pc = W_valM;
    else
        f_pc = F_predPC;

    f_icode = M[f_pc*2+0];
    f_ifun  = M[f_pc*2+1];

    eout << "f_pc      " << hex(f_pc) << endl;
    eout << "f_icode   " << f_icode << endl;
    eout << "f_ifun    " << f_ifun << endl;

    //!does fetched instruction require a regid byte?
    if ( (f_icode == RRMOVL) || (f_icode == IRMOVL) || (f_icode == RMMOVL) || (f_icode == MRMOVL) || (f_icode == OPL) || (f_icode == PUSHL) || (f_icode == POPL) || (f_icode == IADDL))
        need_regids = 1;
    else
        need_regids = 0;

    //!does fetched instruction require a contant word?
    if ( (IRMOVL <= f_icode)&&(f_icode <= MRMOVL) || f_icode == JXX || f_icode == CALL || f_icode == IADDL)
        need_valC = 1;
    else
        need_valC = 0;

    f_valP = f_pc + !!(f_icode != NOP) + need_regids + 4*need_valC;
    if (f_pc == nop_pc) f_valP = nop_pc;
    f_valC  = valC(f_pc, need_regids, need_valC);

    eout << "f_valP    " << f_valP << endl;
    eout << "f_valC    " << f_valC << endl;

    if ( (f_icode == JXX) || (f_icode == CALL))
        new_F_predPC = f_valC;
    else
        new_F_predPC = f_valP;

    new_D_icode = f_icode;
    new_D_ifun  = f_ifun;

    if (need_regids)
    {
        new_D_rA    = M[f_pc*2+2];
        new_D_rB    = M[f_pc*2+3];
    }
    else
    {
        new_D_rA    = NONE;
        new_D_rB    = NONE;
    }

    new_D_valC  = f_valC;
    new_D_valP  = f_valP;
    new_D_pc    = f_pc;

    if (f_icode != NOP)
    {
        instr[f_pc*2] = f_valP - f_pc;
        if ( last < f_pc*2 ) last = f_pc*2;
        eout << "last  = " << last << endl;
        eout << "value = " << f_pc*2 << endl;
    }
}

// DECODE logic
void decode()
{
    //!what register should be used as the A source?
    if ( (D_icode == RRMOVL) || (D_icode == RMMOVL) || (D_icode == OPL) || (D_icode == PUSHL))
        new_E_srcA = D_rA;
    else if ( D_icode == LEAVE)
        new_E_srcA = EBP;
    else if ( (D_icode == POPL) || (D_icode == RET) )
        new_E_srcA = ESP;
    else
        new_E_srcA = NONE;

    //!what register should be used as the B source?
    if ( (D_icode == RMMOVL) || (D_icode == MRMOVL) || (D_icode == OPL) || (D_icode == IADDL))
        new_E_srcB = D_rB;
    else if (D_icode == LEAVE)
        new_E_srcB = EBP;
    else if ( (D_icode == CALL) || (D_icode == RET) || (D_icode == PUSHL) || (D_icode == POPL) )
        new_E_srcB = ESP;
    else
        new_E_srcB = NONE;

    //!what register should be used as the E destination?
    if ( (D_icode == RRMOVL) || (D_icode == IRMOVL) || (D_icode == OPL ) || (D_icode == IADDL))
        new_E_dstE = D_rB;
    else if (D_icode == LEAVE)
        new_E_dstE = ESP;
    else if ( (D_icode == CALL) || (D_icode == RET) || (D_icode == PUSHL) || (D_icode == POPL))
        new_E_dstE = ESP;
    else
        new_E_dstE = NONE;

    //!what register should be used as the M destination?
    if ( (D_icode == MRMOVL) || (D_icode == POPL) )
        new_E_dstM = D_rA;
    else if (D_icode == LEAVE)
        new_E_dstM = EBP;
    else
        new_E_dstM = NONE;


    d_srcA    = new_E_srcA;
    d_srcB    = new_E_srcB;
    d_rvalA   = R[d_srcA];
    d_rvalB   = R[d_srcB];
    //R[W_dstM] = W_valM;
    //R[W_dstE] = W_valE;

    //!what should be the A value?
    //!forward into decode stage for valA
    if ( (D_icode == JXX) || (D_icode == CALL)) //JXX, CALL
        new_E_valA = D_valP;
    else if (d_srcA == E_dstE)
        new_E_valA = e_valE;
    else if (d_srcA == M_dstM)
        new_E_valA = m_valM;
    else if (d_srcA == M_dstE)
        new_E_valA = M_valE;
    else if (d_srcA == W_dstM)
        new_E_valA = W_valM;
    else if (d_srcA == W_dstE)
        new_E_valA = W_valE;
    else
        new_E_valA = d_rvalA;

    if (d_srcB == E_dstE)
        new_E_valB = e_valE;
    else if (d_srcB == M_dstM)
        new_E_valB = m_valM;
    else if (d_srcB == M_dstE)
        new_E_valB = M_valE;
    else if (d_srcB == W_dstM)
        new_E_valB = W_valM;
    else if (d_srcB == W_dstE)
        new_E_valB = W_valE;
    else
        new_E_valB = d_rvalB;

    new_E_icode = D_icode;
    new_E_ifun  = D_ifun;
    new_E_valC  = D_valC;
    new_E_pc    = D_pc;
}

// EXECUTE logic
void execute()
{
    //!select input A to ALU
    if ( E_icode == RRMOVL || E_icode == OPL ) //OPL
        aluA = E_valA;
    else if ( E_icode == IRMOVL || E_icode == RMMOVL || E_icode == MRMOVL || E_icode == IADDL )
        aluA = E_valC;
    else if ( E_icode == CALL || E_icode == PUSHL)
        aluA = -4;
    else if ( E_icode == RET || E_icode == POPL || E_icode == LEAVE)
        aluA = +4;

    //!select input B to ALU
    if ( E_icode == RMMOVL || E_icode == MRMOVL || E_icode == OPL || E_icode >= CALL) //CALL, RET, PUSHL, POPL, IADDL, LEAVE
        aluB = E_valB;
    else if ( E_icode == RRMOVL || E_icode == IRMOVL)
        aluB = 0;

    //!set the ALU function
    if ( E_icode == OPL )
        alufun = E_ifun;
    else
        alufun = 0;         //aluAdd

    if ( E_icode == OPL || E_icode == IADDL)
        set_cc = 1;
    else
        set_cc = 0;

    e_valE = comp(alufun, aluA, aluB);
    new_M_icode = E_icode;
    new_M_valE  = e_valE;
    eout << "e_valE    = " << e_valE << endl;
    new_M_valA  = E_valA;
    new_M_dstE  = E_dstE;
    new_M_dstM  = E_dstM;
    if (E_icode == JXX)
        e_Bch   = Cond(ZF, SF, OF, E_ifun);
    else
        e_Bch   = 0;
    new_M_Bch   = e_Bch;
    new_M_pc    = E_pc;
}

// MEMORY logic
void memory(int cycle)
{
    //!select memory address
    if ( M_icode == RMMOVL || M_icode == MRMOVL || M_icode == PUSHL || M_icode == CALL)
        mem_addr = M_valE;
    else if ( M_icode == POPL || M_icode == RET || M_icode == LEAVE)
        mem_addr = M_valA;

    //!set read control signal
    if ( M_icode == MRMOVL || M_icode == POPL || M_icode == RET || M_icode == LEAVE)
        mem_read = 1;
    else
        mem_read = 0;

    //!set write control signal
    if ( M_icode == RMMOVL || M_icode == PUSHL || M_icode == CALL)
        mem_write = 1;
    else
        mem_write = 0;

    if (mem_read)  m_valM = decimal(mem_addr);

    if (mem_write)
    {
        insert(mem_addr, M_valA);
        sout << "In cycle " << cycle << ":" << endl;
        sout << "M[" << hex(mem_addr) << "] <-  " << shex(M_valA) << endl;
    }


    new_W_icode = M_icode;
    new_W_valE  = M_valE;
    new_W_valM  = m_valM;
    new_W_dstE  = M_dstE;
    new_W_dstM  = M_dstM;
    new_W_pc    = M_pc;
}

// Writeback logic
void write()
{
    if (W_icode != NOP)
        ninstr ++;
}

// Register control, to see if a given stage is bubbled or stalled
void ctrl()
{
    F_bubble = 0;

    if ( (E_icode == JXX)&&(!e_Bch) || (RET == D_icode || RET == E_icode || RET == M_icode) || (W_icode == HALT) )
        D_bubble = 1;
    else
        D_bubble = 0;

    if ( (E_icode == JXX)&&(!e_Bch) || (E_icode == MRMOVL || E_icode == POPL)&&(E_dstM == d_srcA || E_dstM == d_srcB) || (W_icode == HALT) )
        E_bubble = 1;
    else
        E_bubble = 0;

    if (W_icode == HALT)
        M_bubble = 1;
    else
        M_bubble = 0;

    if ( (E_icode == MRMOVL || E_icode == POPL)&&(E_dstM == d_srcA || E_dstM == d_srcB) || (RET == D_icode || RET == E_icode || RET == M_icode) || (W_icode == HALT) )
        F_stall = 1;
    else
        F_stall = 0;

    if ( (E_icode == MRMOVL || E_icode == POPL) && (E_dstM == d_srcA || E_dstM == d_srcB) )
        D_stall = 1;
    else
        D_stall = 0;

    E_stall = 0;

    M_stall  = 0;
}

// update registers with new values
void set_reg()
{
    if (!F_stall)
        F_predPC = new_F_predPC;

    R[W_dstE] = W_valE;
    R[W_dstM] = W_valM;

    if (D_stall)
    {
    }
    else if (D_bubble)
    {
        D_pc    = nop_pc;
        D_icode = NOP;
        D_ifun  = 0;
        D_rA    = NONE;
        D_rB    = NONE;
        D_valC  = 0;
        D_valP  = 0;
    }
    else
    {
        D_pc    = new_D_pc;
        D_icode = new_D_icode;
        D_ifun  = new_D_ifun;
        D_rA    = new_D_rA;
        D_rB    = new_D_rB;
        D_valC  = new_D_valC;
        D_valP  = new_D_valP;
    }

    if (E_bubble)
    {
        E_pc    = nop_pc;
        E_icode = NOP;
        E_ifun  = 0;
        E_valC  = 0;
        E_valA  = 0;
        E_valB  = 0;
        E_dstE  = NONE;
        E_dstM  = NONE;
        E_srcA  = NONE;
        E_srcB  = NONE;
    }
    else
    {
        E_pc    = new_E_pc;
        E_icode = new_E_icode;
        E_ifun  = new_E_ifun;
        E_valC  = new_E_valC;
        E_valA  = new_E_valA;
        E_valB  = new_E_valB;
        E_dstE  = new_E_dstE;
        E_dstM  = new_E_dstM;
        E_srcA  = new_E_srcA;
        E_srcB  = new_E_srcB;
    }

        M_pc    = new_M_pc;
        M_icode = new_M_icode;
        M_Bch   = new_M_Bch;
        M_valE  = new_M_valE;
        M_valA  = new_M_valA;
        M_dstE  = new_M_dstE;
        M_dstM  = new_M_dstM;

        W_pc    = new_W_pc;
        W_icode = new_W_icode;
        W_valE  = new_W_valE;
        W_valM  = new_W_valM;
        W_dstE  = new_W_dstE;
        W_dstM  = new_W_dstM;
}

// let the clock go for a single cycle
void step(int cycle)
{
    ctrl();

    set_reg();

    write();
    eout << "W_FINE" << endl;
    memory(cycle);
    eout << "M_FINE" << endl;
    execute();
    eout << "E_FINE" << endl;
    decode();
    eout << "D_FINE" << endl;
    fetch();
    eout << "F_FINE" << endl;
}

// read from input & initialization
void init()
{
    fin.open(inFile.c_str());

    memset(M, 0, sizeof(M));
    memset(instr, 0, sizeof(instr));
    string line;
    int i, j, k, l, now = -1;
    start = last = -1;
    while (getline(fin, line))
    {
        if (line[2] == ' ') continue;

        for (i = 4, k = 0; line[i] != ':'; i++)
        {
            j = line[i]-'0'; if (j>9) j -= 39;
            k = (k << 4) + j;
        }
        if (start == -1) start = k;
        //if (now   == -1) now   = k;
        now = k * 2;

        i += 2;
        l  = i;
        while ( i < line.length() && line[i] != '|')
        {
            if ((line[i] >= '0' && line[i] <= '9') || (line[i] >= 'a' && line[i] <= 'f'))
            {
                j = line[i]-'0'; if (j>9) j -= 39;
                M[now++] = j;
            }
            i ++;
        }
    }
    fin.close();

    new_F_predPC = start;
    new_D_pc = nop_pc; new_E_pc = nop_pc; new_M_pc = nop_pc; new_W_pc = nop_pc;

    new_D_icode = new_D_ifun = new_D_valC = new_D_valP = 0;                 new_D_rA = new_D_rB = NONE;
    new_E_icode = new_E_ifun = new_E_valC = new_E_valA = new_E_valB = 0;    new_E_dstE = new_E_dstM = new_E_srcA = new_E_srcB = NONE;
    new_M_icode = new_M_ifun = new_M_valA = new_M_valE = new_M_Bch = 0;     new_M_dstE = new_M_dstM = NONE;
    new_W_icode = new_W_valE = new_W_valM = 0;                              new_W_dstE = new_W_dstM = NONE;
    R[ESP] = R[EBP] = start;

    for (i = start; i < now; i++) eout << h[M[i]];
    eout << endl;
}

// generate assembly code
void disasm()
{
    sout.open(asmFile.c_str());

    //sout << "here" << endl;

    int i = start, rA, rB;
    while (1)
    {
        while (instr[i] == 0)
        {
            i++;
            eout << i << endl;
        }

        //sout << "now at " << i << endl;
        f_pc = i/2;
        f_icode = M[i+0];
        f_ifun  = M[i+1];

        sout << "  " << hex(f_pc) << ": ";

        if ( (f_icode == RRMOVL) || (f_icode == IRMOVL) || (f_icode == RMMOVL) || (f_icode == MRMOVL) || (f_icode == OPL) || (f_icode == PUSHL) || (f_icode == POPL) || (f_icode == IADDL))
            need_regids = 1;
        else
            need_regids = 0;

        //!does fetched instruction require a contant word?
        if ( (IRMOVL <= f_icode)&&(f_icode <= MRMOVL) || f_icode == JXX || f_icode == CALL || f_icode == IADDL)
            need_valC = 1;
        else
            need_valC = 0;

        f_valC  = valC(f_pc, need_regids, need_valC);

        if (need_regids)
        {
            rA    = M[i+2];
            rB    = M[i+3];
        }
        else
        {
            rA    = NONE;
            rB    = NONE;
        }

        if (f_icode == HALT)
            sout << "halt" << endl;

        if (f_icode == RET)
            sout << "ret" << endl;

        if (f_icode == LEAVE)
            sout << "leave" << endl;

        if (f_icode == RRMOVL)
            sout << "rrmovl " << reg_name[rA] << ", " << reg_name[rB] << endl;

        if (f_icode == IRMOVL)
            sout << "irmovl " << "$" << shex(f_valC)  << ", " << reg_name[rB] << endl;

        if (f_icode == RMMOVL)
            sout << "rmmovl " << reg_name[rA] << ", " << shex(f_valC) << "(" << reg_name[rB] << ")" << endl;

        if (f_icode == MRMOVL)
            sout << "mrmovl " << shex(f_valC) << "(" << reg_name[rB] << "), " << reg_name[rA] << endl;

        if (f_icode == OPL)
        {
            if (f_ifun == 0)
                sout << "addl " << reg_name[rA] << ", " << reg_name[rB] << endl;
            if (f_ifun == 1)
                sout << "subl " << reg_name[rA] << ", " << reg_name[rB] << endl;
            if (f_ifun == 2)
                sout << "andl " << reg_name[rA] << ", " << reg_name[rB] << endl;
            if (f_ifun == 3)
                sout << "xorl " << reg_name[rA] << ", " << reg_name[rB] << endl;
        }

        if (f_icode == JXX)
        {
            if (f_ifun == 0)
                sout << "jmp " << "$" << thex(f_valC) << endl;
            if (f_ifun == 1)
                sout << "jle " << "$" << thex(f_valC) << endl;
            if (f_ifun == 2)
                sout << "jl "  << "$" << thex(f_valC) << endl;
            if (f_ifun == 3)
                sout << "je "  << "$" << thex(f_valC) << endl;
            if (f_ifun == 4)
                sout << "jne " << "$" << thex(f_valC) << endl;
            if (f_ifun == 5)
                sout << "jge " << "$" << thex(f_valC) << endl;
            if (f_ifun == 6)
                sout << "jg "  << "$" << thex(f_valC) << endl;
        }

        if (f_icode == CALL)
            sout << "call " << "$" << thex(f_valC) << endl;

        if (f_icode == PUSHL)
            sout << "pushl " << reg_name[rA] << endl;

        if (f_icode == POPL)
            sout << "popl " << reg_name[rA] << endl;

        if (f_icode == IADDL)
            sout << "iaddl " << "$" << shex(f_valC) << ", " << reg_name[rB] << endl;

        if (i == last) break;
        i = i + 2 * instr[i];
    }

    sout.close();
}

// print necessary information
void print()
{
        string state;

        fout << "Cycle_" << cycle << endl;
        fout << "--------------------" << endl;

        fout << "FETCH:" << endl;
        fout << "   F_predPC    = " << hex(F_predPC) << endl;
        fout << endl;

        fout << "DECODE:" << endl;
        fout << "   D_icode     = 0x" << h[D_icode] << endl;
        fout << "   D_ifun      = 0x" << h[D_ifun] << endl;
        fout << "   D_rA        = 0x" << h[D_rA] << endl;
        fout << "   D_rB        = 0x" << h[D_rB] << endl;
        fout << "   D_valC      = " << hex(D_valC) << endl;
        fout << "   D_valP      = " << hex(D_valP) << endl;
        fout << endl;

        fout << "EXECUTE:" << endl;
        fout << "   E_icode     = 0x" << h[E_icode] << endl;
        fout << "   E_ifun      = 0x" << h[E_ifun] << endl;
        fout << "   E_valC      = " << hex(E_valC) << endl;
        fout << "   E_valA      = " << hex(E_valA) << endl;
        fout << "   E_valB      = " << hex(E_valB) << endl;
        fout << "   E_dstE      = 0x" << h[E_dstE] << endl;
        fout << "   E_dstM      = 0x" << h[E_dstM] << endl;
        fout << "   E_srcA      = 0x" << h[E_srcA] << endl;
        fout << "   E_srcB      = 0x" << h[E_srcB] << endl;
        fout << endl;

        fout << "MEMORY:" << endl;
        fout << "   M_icode     = 0x" << h[M_icode] << endl;
        fout << "   M_Bch       = " << boo(M_Bch) << endl;
        fout << "   M_valE      = " << hex(M_valE) << endl;
        fout << "   M_valA      = " << hex(M_valA) << endl;
        fout << "   M_dstE      = 0x" << h[M_dstE] << endl;
        fout << "   M_dstM      = 0x" << h[M_dstM] << endl;
        fout << endl;

        fout << "WRITE BACK:" << endl;
        fout << "   W_icode     = 0x" << h[W_icode] << endl;
        fout << "   W_valE      = " << hex(W_valE) << endl;
        fout << "   W_valM      = " << hex(W_valM) << endl;
        fout << "   W_dstE      = 0x" << h[W_dstE] << endl;
        fout << "   W_dstM      = 0x" << h[W_dstM] << endl;
        fout << endl;


        rout << "Cycle_" << cycle << " Instruction_" << ninstr << endl;
        rout << "--------------------" << endl;

        state = "AOK";
        if (F_stall) state = "STA";
        rout << "F: " << state << " @ " << hex(f_pc) << endl;

        state = "AOK";
        if (D_stall) state = "STA";
        if (D_bubble) state = "BUB";
        rout << "D: " << state << " @ " << hex(D_pc) << endl;

        state = "AOK";
        if (E_stall) state = "STA";
        if (E_bubble) state = "BUB";
        rout << "E: " << state << " @ " << hex(E_pc) << endl;

        state = "AOK";
        if (M_stall) state = "STA";
        if (M_bubble) state = "BUB";
        rout << "M: " << state << " @ " << hex(M_pc) << endl;

        state = "AOK";
        if (W_stall) state = "STA";
        if (W_bubble) state = "BUB";
        rout << "W: " << state << " @ " << hex(W_pc) << endl;

        rout << "%eax = " << hex(R[EAX]) << endl;
        rout << "%ebx = " << hex(R[EBX]) << endl;
        rout << "%ecx = " << hex(R[ECX]) << endl;
        rout << "%edx = " << hex(R[EDX]) << endl;
        rout << "%edi = " << hex(R[EDI]) << endl;
        rout << "%esi = " << hex(R[ESI]) << endl;
        rout << "%ebp = " << hex(R[EBP]) << endl;
        rout << "%esp = " << hex(R[ESP]) << endl;
        rout << "  ZF = " << ZF << endl;
        rout << "  OF = " << OF << endl;
        rout << "  SF = " << SF << endl;
        rout << endl;

        if (mem_write) sout << endl;
}

int main()
{
//  GET filename
    freopen("filename.txt", "rt", stdin);

    string dir, filename;
    cin >> dir;

    int i = dir.length() - 1;
    while (dir[i] != '\\')
    {
        filename = dir[i] + filename;
        i--;
    }

    inFile  = dir+".yo";
    outFile = dir+".txt";
    memFile = filename+"_mem.txt";
    regFile = filename+"_reg.txt";
    asmFile = filename+".asm";
//

    init();

    eout << "start = " << start << endl;

    fout.open(outFile.c_str());
    rout.open(regFile.c_str());
    sout.open(memFile.c_str());

    cycle  = 0;
    ninstr = 0;

    while (1)
    {
        step(cycle);

        if (W_icode == HALT) break;
        cycle ++;
    }

    fout.close();
    rout.close();
    sout.close();

    disasm();

    return 0;
}
