#pragma checksum "C:\Users\Назар\source\repos\WebApplication10bbb\WebApplication10bbb\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "60e9a5743d1928fd9caa18aeed66e0924ade5752"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Index.cshtml", typeof(AspNetCore.Pages_Index), null)]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"60e9a5743d1928fd9caa18aeed66e0924ade5752", @"/Pages/Index.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\Назар\source\repos\WebApplication10bbb\WebApplication10bbb\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
            BeginContext(97, 13757, true);
            WriteLiteral(@"
<style>
    #myContainer {
        width: 448px;
        height: 496px;
        background-image: url('images/background.png');
        position: relative;
    }

    #pacman {
        width: 16px;
        top: 16px;
        left: 16px;
        height: 16px;
        position: absolute;
        background-color: yellow;
    }

    #blinky {
        top: 224px;
        left: 184px;
        width: 16px;
        height: 16px;
        position: absolute;
        background-color: red;
    }

    #inky {
        top: 224px;
        left: 184px;
        width: 16px;
        height: 16px;
        position: absolute;
        background-color: deepskyblue;
    }

    #pinky {
        width: 16px;
        top: 224px;
        left: 216px;
        height: 16px;
        position: absolute;
        background-color: pink;
    }

    #clyde {
        width: 16px;
        top: 224px;
        left: 248px;
        height: 16px;
        position: absolute;
        background-co");
            WriteLiteral(@"lor: darkorange;
    }

    .coin {
        width: 4px;
        height: 4px;
        position: absolute;
        background-color: lawngreen;
    }

    .ground {
        width: 4px;
        height: 4px;
        position: absolute;
        background-color: transparent;
    }

    .energizer {
        width: 8px;
        height: 8px;
        position: absolute;
        background-color: mediumblue;
    }
</style>

<p>
    <button id=""sendBtn"">Click Me</button>
    <button id=""pause"">Pause</button>
    <input id=""login"" type=""text"">
</p>

<div id=""myContainer"">



</div>

<div>
    <textarea id=""tf""></textarea>

</div>

<script src=""js/signalr.min.js""></script>

<script>

    var item = 16;

    document.getElementById(""myContainer"").style.backgroundSize = ""448px 496px"";

    var map = [
        [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1],
        [1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2,");
            WriteLiteral(@" 2, 2, 2, 1],
        [1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1],
        [1, 3, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 3, 1],
        [1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1],
        [1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1],
        [1, 2, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 2, 1],
        [1, 2, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 2, 1],
        [1, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 1],
        [1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1],
        [4, 4, 4, 4, 4, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 4, 4, 4, 4, 4],
        [4, 4, 4, 4, 4, 1, 2, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 1, 4, 4, 4, 4, 4],
        [4, 4, 4, 4, 4, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1,");
            WriteLiteral(@" 1, 2, 1, 1, 2, 1, 4, 4, 4, 4, 4],
        [1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 4, 4, 4, 4, 4, 4, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1],
        [4, 4, 4, 4, 4, 1, 2, 2, 2, 2, 1, 4, 4, 4, 4, 4, 4, 1, 2, 2, 2, 2, 1, 4, 4, 4, 4, 4],
        [1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 4, 4, 4, 4, 4, 4, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1],
        [4, 4, 4, 4, 4, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 4, 4, 4, 4, 4],
        [4, 4, 4, 4, 4, 1, 2, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 1, 4, 4, 4, 4, 4],
        [4, 4, 4, 4, 4, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 4, 4, 4, 4, 4],
        [1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1],
        [1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1],
        [1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1],
        [1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1],
        [1, 3, 2, 2, 1, 1, 2, 2, 2, 2,");
            WriteLiteral(@" 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 3, 1],
        [1, 1, 1, 2, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 2, 1, 1, 1],
        [1, 1, 1, 2, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 2, 1, 1, 1],
        [1, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 1],
        [1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1],
        [1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1],
        [1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1],
        [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1],

    ];

    var el = document.getElementById('myContainer');

    function drawWorld() {
        el.innerHTML = '';
        for (var y = 0; y < map.length; y = y + 1) {
            for (var x = 0; x < map[y].length; x = x + 1) {
                if (map[y][x] === 2) {
                    var");
            WriteLiteral(@" yy = y * item + 6;
                    var xx = x * item + 6;
                    el.innerHTML += '<div id=""' + y + ""o"" + x + '"" class=""coin"" style=""top:' + yy + 'px; left:' + xx + 'px""></div>';
                } else if (map[y][x] === 3) {
                    var yy = y * item + 4;
                    var xx = x * item + 4;
                    el.innerHTML += '<div id=""' + y + ""o"" + x + '"" class=""energizer"" style=""top:' + yy + 'px; left:' + xx + 'px""></div>';
                }
            }
            el.innerHTML += ""<br>"";
        }

        el.innerHTML += '<div id=""pacman""></div>';
        el.innerHTML += '<div id=""blinky""></div>';
        el.innerHTML += '<div id=""pinky""></div>';
        el.innerHTML += '<div id=""clyde""></div>';
        el.innerHTML += '<div id=""inky""></div>';

        var w = window.innerWidth;
        el.style.left = (w - 448) / 2;
    }

    drawWorld();

    document.getElementById(""blinky"").style.backgroundSize = ""16px 16px"";

    current_pacman = {
   ");
            WriteLiteral(@"     x: 1,
        y: 1
    }

    let hubUrl = 'https://localhost:44379/stocks';
    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl(hubUrl)
        .configureLogging(signalR.LogLevel.Information)
        .build();
    hubConnection.start();

    document.getElementById(""sendBtn"").addEventListener(""click"", function (e) {
        hubConnection.invoke(""StartGame"");
    });

    document.onkeydown = function (event) {

        if (event.keyCode === 37) {

            hubConnection.invoke(""MovePacmen"", 4);

        }
        else if (event.keyCode === 38) {

            hubConnection.invoke(""MovePacmen"", 8);

        }
        else if (event.keyCode === 39) {

            hubConnection.invoke(""MovePacmen"", 6);

        }
        else if (event.keyCode === 40) {

            hubConnection.invoke(""MovePacmen"", 2);

        }

    };

    previos_pacman = {
        x: 16,
        y: 16
    }

    previos_blinky = {
        x: 11,
        y: 13");
            WriteLiteral(@"
    }

    previos_pinky = {
        x: 11,
        y: 13
    }

    previos_clydi = {
        x: 11,
        y: 13
    }

    previos_inky = {
        x: 11,
        y: 13
    }

    hubConnection.on(""ChangePacmanPosition"", function (pacman_x, pacman_y, score) {

        var elem = document.getElementById(""pacman"");

        var some_coin = document.getElementById(pacman_x + ""o"" + pacman_y);
        some_coin.className = 'ground';

        ObjectMove(pacman_x, pacman_y, previos_pacman.x, previos_pacman.y, elem.id, 12);

        previos_pacman.x = pacman_x;
        previos_pacman.y = pacman_y;

        document.getElementById('tf').textContent = score;

        //elem.style.top = pacman_x*8 + 'px';
        //elem.style.left = pacman_y*8 + 'px';
    });



    hubConnection.on(""ChangeBlinkyPosition"", function (blinky_x, blinky_y, IsFrightened, MovingToHome) {

        var blinky = document.getElementById(""blinky"");
        var time = 15;

        if (MovingToHome == ");
            WriteLiteral(@"true) {
            blinky.style.backgroundColor = 'white';
            time = 6;
        }
        else if (IsFrightened == true) {
            blinky.style.backgroundColor = 'darkblue';
            time = 37;
        }
        else {
            time = 15;
            blinky.style.backgroundColor = 'red';
        }

        //if (previos_blinky.y < blinky_y)
        //{
        //    blinky.style.backgroundImage = ""url('images/BlinkyRight.png')"";
        //}
        //else if (previos_blinky.y > blinky_y)
        //{
        //    blinky.style.backgroundImage = ""url('images/BlinkyLeft.png')"";
        //}

        ObjectMove(blinky_x, blinky_y, previos_blinky.x, previos_blinky.y, blinky.id, time);

        previos_blinky.x = blinky_x;
        previos_blinky.y = blinky_y;

    });

    hubConnection.on(""ChangePinkyPosition"", function (pinky_x, pinky_y, IsFrightened, MovingToHome) {

        var pinky = document.getElementById(""pinky"");

        var time = 15;

        if (Mo");
            WriteLiteral(@"vingToHome == true) {
            pinky.style.backgroundColor = 'white';
            time = 6;
        }
        else if (IsFrightened == true) {
            pinky.style.backgroundColor = 'darkblue';
            time = 37;
        }
        else {
            time = 15;
            pinky.style.backgroundColor = 'pink';
        }

        ObjectMove(pinky_x, pinky_y, previos_pinky.x, previos_pinky.y, pinky.id, time);

        previos_pinky.x = pinky_x;
        previos_pinky.y = pinky_y;
    });

    hubConnection.on(""ChangeInkyPosition"", function (inky_x, inky_y, IsFrightened, MovingToHome) {

        var inky = document.getElementById(""inky"");

        var time = 15;

        if (MovingToHome == true) {
            inky.style.backgroundColor = 'white';
            time = 6;
        }
        else if (IsFrightened == true) {
            inky.style.backgroundColor = 'darkblue';
            time = 37;
        }
        else {
            time = 15;
            inky.style.backgr");
            WriteLiteral(@"oundColor = 'deepskyblue';
        }

        ObjectMove(inky_x, inky_y, previos_inky.x, previos_inky.y, inky.id, time);

        previos_inky.x = inky_x;
        previos_inky.y = inky_y;
    });


    hubConnection.on(""ChangeClydePosition"", function (clyde_x, clyde_y, IsFrightened, MovingToHome) {

        var clyde = document.getElementById(""clyde"");

        var time = 15;

        if (MovingToHome == true) {
            clyde.style.backgroundColor = 'white';
            time = 6;
        }
        else if (IsFrightened == true) {
            clyde.style.backgroundColor = 'darkblue';
            time = 37;
        }
        else {
            time = 15;
            clyde.style.backgroundColor = 'darkorange';
        }

        ObjectMove(clyde_x, clyde_y, previos_clydi.x, previos_clydi.y, clyde.id, time);

        previos_clydi.x = clyde_x;
        previos_clydi.y = clyde_y;
    });

    hubConnection.on(""EndGame"", function () {
        alert(""You win!"");
    });

   ");
            WriteLiteral(@" var p = false;

    document.getElementById(""pause"").addEventListener(""click"", function (e) {
        if (p) {
            p = false;
            document.getElementById(""pause"").textContent = ""Unpause"";
        }
        else {
            p = true;
            document.getElementById(""pause"").textContent = ""Pause"";
        }
        hubConnection.invoke(""Pause"");
    });

    function ObjectMove(x, y, px, py, object_id, time) {

        var object = document.getElementById(object_id);

        if (py < y) {
            var yy = y * item - item;

            var pos = 0;
            var id = setInterval(frame, time);
            function frame() {
                if (pos == 8) {
                    clearInterval(id);
                } else {
                    pos++;
                    yyy = yy + pos * 2;
                    object.style.left = yyy + 'px';
                }
            }
        }
        else if (py > y) {
            var yy = y * item + item;

       ");
            WriteLiteral(@"     var pos = 0;
            var id = setInterval(frame, time);
            function frame() {
                if (pos == 8) {
                    clearInterval(id);
                } else {
                    pos++;
                    yyy = yy - pos * 2;

                    object.style.left = yyy + 'px';
                }
            }
        }
        else if (px < x) {
            var xx = x * item - item;
            var pos = 0;
            var id = setInterval(frame, time);
            function frame() {
                if (pos == 8) {
                    clearInterval(id);
                } else {
                    pos++;
                    xxx = xx + pos * 2;
                    object.style.top = xxx + 'px';
                }
            }
        }
        else if (px > x) {
            var xx = x * item + item;
            var pos = 0;
            var id = setInterval(frame, time);
            function frame() {
                if (pos == 8) {
             ");
            WriteLiteral(@"       clearInterval(id);
                } else {
                    pos++;
                    xxx = xx - pos * 2;
                    object.style.top = xxx + 'px';
                }
            }
        }


    }

    window.addEventListener(""resize"", myFunctionq);

    
    function myFunctionq() {
        var w = window.innerWidth;
        el.style.left = (w - 448) / 2;
    }
</script>

<script>
 
</script>

");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication10bbb.Pages.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebApplication10bbb.Pages.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebApplication10bbb.Pages.IndexModel>)PageContext?.ViewData;
        public WebApplication10bbb.Pages.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
