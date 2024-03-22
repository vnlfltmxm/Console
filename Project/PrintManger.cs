using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class PrintManger
    {
        Map map;
        Player player;


        public PrintManger(Map map,Player player) 
        {
            this.map = map;
            this.player = player;


        }

        public void PrintMenu() 
        {
                Console.WriteLine(" ┌─────────────────────────────────────────────────────────┐      ");
                Console.WriteLine(" │                                                         │     ");
                Console.WriteLine(" │                      봄버맨                             │     ");
                Console.WriteLine(" │                                                         │     ");
                Console.WriteLine(" │                    게임 설명                            │     ");
                Console.WriteLine(" │         맵에 있는 모든 상자를 부수면 클리어 됩니다      │     ");
                Console.WriteLine(" │         몬스터에 닿거나 폭발에 휘말리면 사망합니다      │     ");
                Console.WriteLine(" │                                                         │     ");
                Console.WriteLine(" │                   아이템 설명                           │     ");
                Console.WriteLine(" │           ↑ : 폭탄의 최대 설치 수가 증가합니다         │     ");
                Console.WriteLine(" │            $ : 폭탄의 폭발 길이가 증가합니다            │     ");
                Console.WriteLine(" │                                                         │     ");
                Console.WriteLine(" └─────────────────────────────────────────────────────────┘      ");
                Console.WriteLine("       게임을 시작하려면 Enter키를 눌러주세요");

        }

        public void PrintLogo()
        {
            string s = @"                                                   
                              . -.                                                             
                              ;,;...                                                           
             .,--~--,.     -~.-;~:*             ,,,.   .,,,,...,,,.             ...  ,.   ...  
            .:.    .,~.     ~,-,,~.    ;~  ,;  --..-:  ;.....!;...-:   ;  ~~    ~.; ~,-- ,-,-  
            ~.        :.    !*!:.:~   -,; ,~*. ~  . .~.~     *, -- .- ::,,~*   :. ;,;  : :.,;  
           .~    .    ,, .~=$!~,=~   ,~ ! ~ !, ~ ;*, *~  ;*=== .!*. !,,,~~ *  -.  :~-  ; ~ ;:  
           ~   ~!!;   !;*=*!!*=*;    :  *:. ;--, =*..!; .!::~: :;= -!: .=. *..~ ~ ~;   ~-, =-  
          -,  .*;!~  ~*$;:~:::;!=.  :.  =,  :-;  -  !!~ .::;:, :: ,**   .  !,; -= -= . .* .!,  
         .:   ;*!,  ~==;,  ~::;;;! ~.   ,   ~:-    ~*!.    ~=    ~*!,      ;;..=$ .; !  : ~!.  
         ~    -.   ;*$;~   ~~:;;;!.-        -*  ,.  ;!  ,-~*~   .*!: -   ~ :~  .. ., *-   ;:   
         ~        ~*$!::~---~:;;;!;       . ,* ~!=  :, ~!!;!  :  =; ,=  -!     ..   -!;   *,   
        ;          ,#;;:~~-~~:;;!!. ~.   ;, .- *!;  ;  !!;:: ,=  !, **  =*  .*!*=   *~:..,!    
       -.    .     -*;;:~~~~::;;!*.,=.  ,!.    !~  :!     :~ :*.   -!!.~;!..!;- ~;!*!-.*!!:    
       ~   ;!!*-   ~*;;::::::;;;:* **   !!.       :!-     *,.*!~~:;*~,!;:,!!!-   -;:~. .,,.    
      :   .!;;;~   ~*;;;;:;;;;;;:!:;!  ,!;.     ,*!!~~::;*!*!!,:;;::. -~. .,.                  
     .,   !!;!:   .*=!!!;;;;!;!:$:;~:  =:~--~;**!;~.;!!!;::...  ...                            
     :   -*!;,   ,*!$!!!!!!!;;:*:*;.!**;-.;!;;:~-.                                             
    ~.   ..     :!!~:=!!!!!!;:==*!.  ;:~                                                       
    ~         ~*!:.  ;$!;;;;*;;~-,                                                             
   ;.      ,~=!;-     .;=$=:.                                                                  
  -,  .,~!*!!;,.                                                                               
  :;!**!;::~.                                                                                  
  .;!:-.                                                                                       
                                                                                               
  
";
            string[] b = s.Split("\n");
            foreach (string s2 in b)
            {
                Console.WriteLine(s2);
            }
        }


        public string[] PrintBoom()
        {
           string s = @"
             
                                             ~,               
                                              ~,  ..        ,  
                                               ~. :.  ~.   !   
                                               ,:,~- ~.   :    
                                              .,,.-~~-  --.    
                          .                  .~.,-~. ~ ~-,     
                                          ..  -~:    -,.-      
                                        .~:-.. ..      ~  ..   
                                          .-. ..       ..,;    
                             ..,....        -~           --. ..
                          ,,,~!*==!:--,. .. --.        ..  .-;~
                .      .,-;!**==$$##@@=~.-:- .,-.     .:~,     
                      .-;;!!*==$$#####=*;;!!~..-,      ,.      
                     ,::;!!*==$$##@#$===###$:,~~~. .,. .-,     
                   .-::;!!*===$##@@@@#==#@#;::~,~, -,,.~,--,   
                  .~:~:;!**==$##@@@@#**=$@#!-,~,-~ ~.-.- .~,   
                 .~~~::;**=$$##@@@@#==$!*#=;~~*~-~,,..--       
                 -~-~:;!*==$##@@@@@##=!::=$*!=#*,~~   -,       
                ,~-~~:!*==$$#@@@@@@#=;:;!*==###$-~:.   ~-      
               .:--~~:*==$$##@@@@@@$!!***=====$@*;~.   -:.     
               ~~--~~;==$$##@@@@@@@#=**=$@@=;*$@@*,     :      
              .:,,-~:*=$$##@@@@@@@@@$*=#@@@=;!#@@=,     ,,     
              ~~..-~:==$##@@@@@@@@@@#=$@@@$;:=@@@$-      ~     
              ;, .-~!$$##@@@@@@@@@@@@###@#!,;#@@@@;.     ,     
             .;. .-~=$##@@@@@@@@@@@@@@@$=;--!#@@@@#,           
             -;. ,-~$$#@@@@@@@@@@@@@@@@@$*!*#@@@@@@-           
             ;~. ,-~###@@@@@@@@@@@@@@@@@@@@@@@@@@@@-           
             *-  ,,~#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@~           
             *,. .,~@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@:.    .     
             *,...,~@@@@@@@@@@@@@@@@@@@@@@@@@@@@@$#;.          
             =-...,~@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*#:           
             $~,.,,~$@@@@@@@@@@@@@@@@@@@@@@@@@@@@;$~           
             =;,,,,-!@@@@@@@@@@@@@@@@@@@@@@@@@@@#:$-           
             ;$,,,--:@@@@@@@@@@@@@@@@@@@@@@@@@@@=:$-           
             ,#----~:#@@@@@@@@@@@@@@@@@@@@@@@@@@;:$-           
              @;~-~~:*@@@@@@@@@@@@@@@@@@@@@@@@@#:!;.           
              =#~~~~:;@@@@@@@@@@@@@@@@@@@@@@@@@*-=-            
              ,@!~~::;*@@@@@@@@@@@@@@@@@@@@@@@#:~*-            
              .##::::;!#@@@@@@@@@@@@@@@@@@@@@@*-*~.            
               -@$;:;;!=@@@@@@@@@@@@@@@@@@@@@$::*-             
               .*@=;;;!*=@@@@@@@@@@@@@@@@@@@@;-*~.             
                ,@@*!!!**$@@@@@@@@@@@@@@@@@@*-!:.              
                 ,@#=!***=$@@@@@@@@@@@@@@@@=~!!,               
                  -@@$**==$#@@@@@@@@@@@@@@=:**,                
                   ,@@#===$#@@@@@@@@@@@@@*!$*,                 
                    ,=@@#$$#@@@@@@@@@@@#*$@:.                  
                     .~@@@##@@@@@@@@@@@@@$-                    
             
";
             
            string[] b = s.Split("\n");
            return b;


       }

        public virtual void PrintMap()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < map.map.GetLength(0); i++)
            {
                for (int j = 0; j < map.map.GetLength(1); j++)
                {

                    Console.BackgroundColor = ConsoleColor.Gray;
                    switch (map.map[i, j])
                    {
                        case eMapState.NULL:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("■");
                            Console.ResetColor();
                            break;
                        case eMapState.BOX:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("■");
                            Console.ResetColor();
                            break;
                        case eMapState.FIRELENGTHITEM:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("$ ");
                            Console.ResetColor();
                            break;
                        case eMapState.PLAYER:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("■");
                            Console.ResetColor();
                            break;
                        case eMapState.MONSTER:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("■");
                            Console.ResetColor();
                            break;
                        case eMapState.BOOM:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("●");
                            Console.ResetColor();
                            break;
                        case eMapState.WILL:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("▣");
                            Console.ResetColor();
                            break;
                        case eMapState.FIRE:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("♨");
                            Console.ResetColor();
                            break;
                        case eMapState.BOOMPLUSITEM:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("↑");
                            Console.ResetColor();
                            break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Black;
                Console.ResetColor();
                Console.WriteLine();

            }

        }

        public void PrintEX()
        {
            string s = @"  
               
                           ..                               
                           ,,                               
       ,.                  ,,,                     .,       
        ,.                 ,,,                    .,        
        .,.               .,,,,                  .,.        
         ,,,              .,,,,                 ,,,         
          ,,,             .,,,,,               ,,,          
          .,,,            ,,,,,,              ,,,.          
           ,,,,           ,,,,,,,            ,,,,           
           .,,,,      .   ,,,,,,,.   .     .,,,,.           
            ,,,,,.    .. .,,,,,,,,  .     .,,,,,            
             ,,,,,.    , .,,,,,,,,. ,    .,,,,,             
             ,,,,,,.   ,..,,,,,,,,,.,   .,,,,,.             
              ,,,,,,,  ,,,,,,,,,,,,,,  ,,,,,,,              
              .,,,,,,, ,,,,,,,,,,,,,, ,,,,,,,.              
               ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,               
                ,,,,,,,,,,,,,,,,,,,,,,,,,,,,                
                .,,,,,,,,,,,,,,,,,,,,,,,,,,.                
                 ,,,,,,,,,,,,,,,,,,,,,,,,,,                 
             ..   ,,,,,,,,,,,,,,,,,,,,,,,,   ..             
             .,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,.             
              .,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,.              
               .,,,,,,,,,,,,,,,,,,,,,,,,,,,,.               
                .,,,,,,,,,,,,,,,,,,,,,,,,,,.                
                 .,,,,,,,,,,,,,,,,,,,,,,,,.                 
              .,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,.              
         .,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,.         
         ...,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,...         
               ....,,,,,,,,,,,,,,,,,,,,,,...                
                      .,,,,,,,,,,,,,,.                      
                    ,,,,,,,,,,,,,,,,,,,,                    
                .,,,,,,,,,,,,,,,,,,,,,,,,,,.                
            .,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,.            
            .,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,.            
                .,,,,,,,,,,,,,,,,,,,,,,,,,,.                
                 .,,,,,,,,,,,,,,,,,,,,,,,,.                 
                .,,,,,,,,,,,,,,,,,,,,,,,,,,.                
               .,,,,. ,,,,,,,  ,,,,,,, .,,,,.               
              .,,,.   ,,,,,,.  .,,,,,,   .,,,.              
             .,,.     ,,,,,,    ,,,,,,     .,,.             
            .,,       ,,,,,      ,,,,,       ,,.            
           .,         ,,,,        ,,,,         ,.           
          .          .,,,.        .,,,.          .          
                     ,,,.          .,,,                     
                     ,,,            ,,,                     
                     ,,              ,,                     
                     ,.              .,                     
                     ,                ,                     
                                                            
 
";

            string[] b = s.Split("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();

            for (int i = 10; i > 0; i--)
            {
                if (i % 2 != 0) Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.White;
                
                Console.Clear();
                foreach (string s2 in b)
                {
                    Console.WriteLine(s2);
                }

                Console.SetCursorPosition(0, 0);
                Thread.Sleep(10);

            }
            
            Console.ResetColor();
            Thread.Sleep(2000);
            Console.Clear();
        }

        public void PrintAnime()
        {
            for (int i = 10; i > 0; i--)
            {
                if (i % 2 != 0) Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();

                foreach (string s in PrintBoom())
                {
                    Console.WriteLine(s);
                }

                if (i > 5) Thread.Sleep(50 * i);
                Thread.Sleep(50 * i);

            }

            PrintEX();
        }

        public void PrintState()
        {
            Console.SetCursorPosition(map.map.GetLength(1)* 2+2, map.map.GetLength(0) / 3);
            Console.WriteLine($"설치 가능 폭탄 개수 : {player.maxBoomCount}");
            Console.SetCursorPosition(map.map.GetLength(1) * 2+2, map.map.GetLength(0) / 2);
            Console.WriteLine($"폭탄의 폭발 길이 : {player.fireLength - 1}");
        }

        public void PrintControl()
        {
            Console.SetCursorPosition(0, map.map.GetLength(0) + 1);
            Console.WriteLine($"이동 : ← , ↑ , ↓ , →");
            Console.WriteLine($"폭탄 설치 : Spacebar ");
        }

        public void PrintGameClear()
        {
            Console.Clear();

            string s = @"
       .~:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::~       
       ;@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-      
       ;@=:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::$@-      
       ;@;                                                                                 =@-      
       ;@;                                                                                 =@-      
       ;@;                                                                                 =@-      
       ;@;                                                                                 =@-      
       ;@;     ---           ---                                                           =@-      
       ;@;   ..$$=-.         $#$,                                                          =@-      
       ;@;   ;=---*~         ,:$,                                                          =@-      
       ;@;   *@  .:-          -$,             ;;:.            ;;;,             -!..;!~     =@-      
       ;@;   *@               -$,             #@$-            #@#~             :@,-@@*    .=@-      
       ;@;   *@               -$,           ;$,,-*;           ,,-!;.           :@#*,,.     =@-      
       ;@;   *@               -$,           !@,.-=!           ..,**.           :@#=        =@-      
       ;@;   *@               -$,           !@@@@@;           $@@@*.           :@,         =@-      
       ;@;   *@               -$,           !@~~~~, ~        !~~~=*.           :@,         =@-      
       ;@;   ;=~---,          -#:,          :*~---, :        *~-~=*.           :@,         =@-      
       ;@;    .#@@@;          -@@;            #@@@;           $@@@*.           :@,         =@-      
       ;@;     ::::,          .::-            ~:::-           ~:::-            ,:.         =@-      
       ;@;                                                                                 =@-      
       ;@;                                                                                 =@-      
       ;@;                                                                                 =@-      
       ;@;                                                                                 =@-      
       ;@!                                                                                 =@-      
       ;@$!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!#@-      
       ~$###################################################################################$,      
        ------------------------------------------------------------------------------------,       

";

            string[] b = s.Split("\n");
            foreach (string s2 in b)
            {
                Console.WriteLine(s2);
            }
        }

        public void PrintGameOver()
        {
            Console.Clear();

            string s = @"

          -####@,  ..=@#@~. .!!.    .~= ;@@####!       :###$,  -@@.  .##,.$@####$~ =@@###@:.        
        .~==,,-**..-$=:,==;. !#;. .,*#= ;@$,,,,.     .-$!,-$*- -@@.  .##,.$@~,,,,. =@;,,,*#~        
        .$$~  .,,..*@-. ,*#~ !@$-..:#@= ;@$....      ,#=,. :#$ -@@.  .##,.$#-....  =@:  ,*#~        
        .#$,      .=@,   !@~ !@;=~:;=@= ;@@###=      ,@=   -@@ -@@.  .##,.$@####~  =@:  ;@:.        
        .#$, ,*##,.=@$$$$#@~ !@: ;!.=@= ;@=....      ,@=   -@@ -#@, .,#$,.$#-...   =@#$$#!.         
        .$$- .-$@,.=@-,,,*@~ !@: ~! =@= ;@=          ,#=, .:## .-=$,~=$,..$#-      =@;,,;$:.        
         ~=*..-=@,.=@,   !@~ !@: ., =@= ;@$.....     .~#;,,$*~  .-#$$#~. .$#-..... =@:  ,*$~        
         .-###$~@,.=@.   !@~ !@:    =@= ;@@####!       :@##$.     .#$-   .$@####$~ =@:  .!@:        

";

            string[] b = s.Split("\n");
            foreach (string s2 in b)
            {
                Console.WriteLine(s2);
            }

        }
    }
}
