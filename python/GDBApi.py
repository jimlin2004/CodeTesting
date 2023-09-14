import sys
from GDB.GDBManager import GDBManager

if __name__ == "__main__":
    gdbManager = GDBManager()
    # argv[1] -> exe path
    # argv[2] -> input path
    # argv[3] -> output path
    gdbManager.run(sys.argv[1], sys.argv[2], sys.argv[3])
    
    notifyMsg = gdbManager.parseNotifyMsg()
    
    if (notifyMsg["message"] == "stopped"):
        payload = notifyMsg["payload"]
        if (payload["reason"] != "exited-normally"):
            sys.stderr.write(f"Error casued: {payload['signal-meaning']}\n")
            sys.stderr.write(f"File: {payload['frame']['fullname']}\n")
            sys.stderr.write(f"Line: {payload['frame']['line']}\n")
            sys.stderr.write(f"Function: {payload['frame']['func']}\n")
            
            errorInfo = gdbManager.getError()
            for info in errorInfo:
                sys.stderr.write(info["payload"])
                
    sys.stdout.flush()
    sys.stderr.flush()