# Disclaimer
The majority of this project (S7evemetry.FH4 & S7evemetry.FM7) was taken from an existing GitHub repository by [Geoffrey Vancoetsem "here"](https://github.com/geeooff/forza-data-web). I have included the Licence file and kept the original copyright on any code that remained untouched, this is here to include credit to Geoffrey for his work. 

# Forza Data Web (_Work in progress_)
Forza Motorsport 7 / Horizon 4 Data-Out receiver

Based on [Turn10 official specifications here](https://forums.forzamotorsport.net/turn10_postst128499_Forza-Motorsport-7--Data-Out--feature-details.aspx).

## Protocol compatibility

| Game               | Sled     | Car Dash | _Horizon_ |
|--------------------|----------|----------|-----------|
| Forza Motorsport 7 | Yes      | Yes      | N/A       |
| Forza Horizon 4    | Yes      | Yes      | No        |

_Note_ : Forza Horizon 4 is actually using an undocumented protocol. Car Dash data has been found however there are 2 undocumented FH4 sections



### Enable Data-Out feature in game

Start Forza Motorsport 7 or Forza Horizon 4 on your Windows 10 computer or your Xbox.
Go to game options, then _HUD_ options. At the bottom of the screen :
1. `Data Out IP Address` : enter the IP Address of **the computer that will run the console program**
2. `Data Out IP Port` : enter the network port you want to **listen on this computer** (1024 to 65535)
3. `Data Out Packet Format` : choose **Sled** or **Car Dash**, but you will get more data using Car Dash format. Forza Horizon 4 does not have this option.
4. `Data Out` : set to **ON**