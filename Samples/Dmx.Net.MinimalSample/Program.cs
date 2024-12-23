using Dmx.Net.Common;
using Dmx.Net.Controllers;

var timer = new DmxTimer();
var controller = new OpenDmxController(timer);

Console.WriteLine("Starting...");

// Make sure your Open DMX interface is connected!
controller.Open(0);

Console.WriteLine("DMX Open");

// Set values of the channel range (1-14)
controller.SetChannelRange(1, 255, 0, 255, 0, 0, 0, 0, 
                              255, 255, 0, 0, 0, 0, 0);

// Don't forget to start the timer.
timer.Start();

Console.WriteLine("DMX initial channels sent");

Thread.Sleep(2000);

Console.WriteLine("STROOOOOBE");

// Set values of the channel range (1-14)
controller.SetChannelRange(1, 255,   0, 255, 255,   0, 240,   0,
                              255, 255,   0,   0,   0, 250,   0);

Thread.Sleep(5000);


byte red1 =0,   red2=128;
byte green1=128, green2=0;
byte blue1=0,  blue2=64;

Thread.Sleep(2000);

for(; ; )
{
    ++red1;     ++red2;
    ++green1; ++green2;
    ++blue1; ++blue2;
    controller.SetChannelRange(1, 255, red1, green1, blue1, 0, 0, 0,
                                  255, red2, green2, blue2, 0, 0, 0);
    Console.WriteLine("DMX bumped");

    Thread.Sleep(5);
}


// Cleanup, ensure all channels are set to 0
timer.Dispose();
controller.Dispose();