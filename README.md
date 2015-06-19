# UmdhViz
UMDH Diff Visualizer

UMDH(User-mode Dump Heap)[https://support.microsoft.com/ko-kr/kb/268343/en-us] is a nice tool for capturing and 
analyzing memory status of Windows process. Example usage is:

1. Run `MyApp.exe`.
2. Run `gflags` for start memory allocation tracing.
3. Run `umdh` for storing memory status into a text file A.
4. Run `umdh` again for storing another memory status into a text file B after `MyApp.exe` takes more memory.
5. Run `umdh` for creating a diff file between A and B.

After opening the diff file, you might be frustrated because it cannot tell you where hotspot of memory allocation lies. 
*UmdhViz* here will tell instead.

How to use
==========
Build and run this source files. Visual Studio is needed.
Click File => Open and select your UMDH Diff file.
Select the hot spot allocation at left pane and enjoy seeing its call stack at right pane!
![Screen shot](http://i.imgur.com/1WV3cBB.png)

Etc.
=======
Don't forget to click *Do you know ProudNet?* if you are interested to developing a game where a cutting edge networking technology is needed. :)
