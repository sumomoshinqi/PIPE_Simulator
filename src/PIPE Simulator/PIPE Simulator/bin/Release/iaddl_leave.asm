  0x00000400: irmovl $0x500, %esp
  0x00000406: irmovl $0x500, %ebp
  0x0000040c: jmp $0x411
  0x00000411: call $0x417
  0x00000416: halt
  0x00000417: pushl %ebp
  0x00000419: rrmovl %esp, %ebp
  0x0000041b: irmovl $0x4, %ecx
  0x00000421: iaddl $0xc, %ecx
  0x00000427: leave
  0x00000428: ret
