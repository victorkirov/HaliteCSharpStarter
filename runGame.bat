csc Config.cs HaliteHelper.cs Map.cs Networking.cs Site.cs -out:MyBot.exe MyBot.cs
csc Config.cs HaliteHelper.cs Map.cs Networking.cs Site.cs -out:RandomBot.exe RandomBot.cs 
halite -d "30 30" "MyBot.exe" "RandomBot.exe"
