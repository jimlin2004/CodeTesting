from pygdbmi.gdbcontroller import GdbController
import sys
import time

if __name__ == "__main__":
    consoleInfo = []
    gdbmi = GdbController()
    # argv[1] -> the path of exe
    gdbmi.write(f"file {sys.argv[1]}")
    
    startTime = time.process_time()
    # argv[2] -> the path of input.txt
    # argv[3] -> the path of output.txt
    res = gdbmi.write(f"run < {sys.argv[2]} > {sys.argv[3]}")
    endTime = time.process_time() - startTime
    for line in res:
        if (line["type"] == "console"):
            string = line["payload"]
            if (not (string.startswith("Starting program") or string.startswith("[New Thread"))):
                consoleInfo.append(string)
        elif (line["type"] == "notify"):
            if (line["message"] == "stopped"):
                payload = line["payload"]
                if (payload["reason"] != "exited-normally"):
                    sys.stderr.write(f"Error casued: {payload['signal-meaning']}\n")
                    sys.stderr.write(f"File: {payload['frame']['fullname']}\n")
                    sys.stderr.write(f"Line: {payload['frame']['line']}\n")
                    sys.stderr.write(f"Function: {payload['frame']['func']}\n")
                    
                    for info in consoleInfo:
                        sys.stderr.write(info)
                        
    sys.stdout.write(f"{endTime}\n")