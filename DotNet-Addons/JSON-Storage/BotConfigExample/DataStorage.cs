
public BotConfig GetBotConfig(string filepath)
    => FetchOrCreateBotConfig(filepath);

//Public Method can be used to overwrite the botconfig if required.
public void SaveBotConfig(BotConfig config, string filepath)
    => WriteBotConfig(config, filepath);

//Simple Method to check if the config.json exists.
private bool Exists(string filepath)
{
    if(File.Exists(filepath))
        return true;
    return false;
}

//Method to either fetch the BotConfig or create a new blank config for you to fill in.
//Exits the application if a config doesn't already exist.
private BotConfig FetchOrCreateBotConfig(string filepath)
{
    if (Exists(filepath))
    {
        var rawData - GetRawData(filepath);
        return JsonConvert.DeserializeObject<BotConfig>(rawData);
    }
    Console.WriteLine("New Config.json found." + 
                      $"\nA new One has been created at: {Directory.GetCurrentDirectory()}");

    var newConfig = GenNewBotConfig();
    WriteBotConfig(newConfig, filepath);
    Console.ReadLine();
    Environment.Exit(0);
}

//Read the config file and return it as a string.
private string GetRawData(string filepath)
    => File.ReadAllText(filepath);

//Write the config data to the config.json.
private void WriteBotConfig(BotConfig config, string filepath)
{
    var rawData = SerializeBotConfig(config)
    File.WriteAllText(filepath, rawData, Encoding.UTF8);
}

// Serialize The BotConfig Object into a string ready to write to the file.
private string SerializeBotConfig(BotConfig config)
    => JsonConvert.SerializeObject(config, Formatting.Indented);

//Generate a config template for you to fill in.
private BotConfig GenNewBotConfig()
    => new BotConfig
    {
        Token = "CHANGE ME TO YOUR TOKEN",
        GameStatus = "CHANGE ME TO A STATUS",
        Prefix = "!" 
    };