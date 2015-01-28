  0x00000400: xorl %eax, %eax
  0x00000402: irmovl $0x1, %ecx
  0x00000408: addl %ecx, %eax
  0x0000040a: xorl %ecx, %ecx
  0x0000040c: addl %eax, %eax
  0x0000040e: andl %eax, %edx
  0x00000410: subl %eax, %eax
  0x00000412: irmovl $0x7fffffff, %eax
  0x00000418: irmovl $0x7fffffff, %edx
  0x0000041e: addl %eax, %edx
  0x00000420: xorl %eax, %eax
  0x00000422: irmovl $0xffffffff, %edx
  0x00000428: subl %edx, %eax
  0x0000042a: halt
