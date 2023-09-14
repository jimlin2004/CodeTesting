"""
會被放在embedded python的Lib中，如此python311._pth才能import此檔案
"""

import subprocess
from pygdbmi import gdbmiparser

class GDBManager:
    def __init__(self) -> None:
        self.consoleMsg = []
        self.notifyMsg = []
    def run(self, exePath: str, inputPath: str, outputPath: str):
        process = subprocess.Popen("gdb -i=mi2", shell = True, stdin = subprocess.PIPE, stdout = subprocess.PIPE)
        process.stdin.write(f"file {exePath}\n".encode())
        
        process.stdin.write(f"run < {inputPath} > {outputPath}\n".encode())
        process.stdin.write("exit".encode())
        process.stdin.close()
        
        commandStep = 0 # "(gdb)"的出現次數 [第三次是程式的開始及結束訊息]
        
        for lineEncode in process.stdout.readlines():
            line = lineEncode.decode()
            if (line == "(gdb) \n"):
                commandStep += 1
            if (commandStep == 3):
                if (line[0] == '~'):
                    self.consoleMsg.append(line)
                if (line[0] == '*'):
                    self.notifyMsg.append(line)
                
        process.wait()
    def parseNotifyMsg(self):
        return gdbmiparser.parse_response(self.notifyMsg[0])
    def getError(self):
        msg = []
        for line in self.consoleMsg:
            msg.append(gdbmiparser.parse_response(line))
        return msg