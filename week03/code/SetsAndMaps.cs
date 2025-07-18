using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        var Dictionary = new Dictionary<string, double>();
        foreach (var word in words)
        {
            var reversed = new string(word.Reverse().ToArray());
            if (Dictionary.ContainsKey(reversed))
            {
                Dictionary[reversed] += 1;
            }
            else
            {
                Dictionary[reversed] = 1;
            }
        }
        var pairs = new List<string>();
        foreach (var word in words)
        {
            var reversed = new string(word.Reverse().ToArray());
            if (Dictionary.ContainsKey(word) && Dictionary.ContainsKey(reversed) && word != reversed)
            {
                pairs.Add($"{word} & {reversed}");
                // Remove both words to avoid duplicates
                Dictionary.Remove(word);
                Dictionary.Remove(reversed);
            }

        }
        return pairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(","); // Split the line by commas
            // TODO Problem 2 - ADD YOUR CODE HERE
            if (fields.Length < 4) continue; // Ensure there are enough fields
            var degree = fields[3].Trim(); // Get the degree from the 4th column
            if (string.IsNullOrEmpty(degree)) continue; // Skip empty degrees
            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++; // Increment the count if the degree already exists
            }
            else
            {
                degrees[degree] = 1; // Initialize the count if the degree does not exist
            }
        }

        return degrees; // Return the dictionary containing degree counts
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        if (string.IsNullOrWhiteSpace(word1) || string.IsNullOrWhiteSpace(word2))
            return false;
        return false;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        // Exceeding requirements: I added comments here to better understand and explain the code.
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson"; // URL to fetch earthquake data
        using var client = new HttpClient(); // Create an instance of HttpClient to send requests
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri); // Create a GET request message for the specified URI
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream(); // Send the request and read the response stream
        using var reader = new StreamReader(jsonStream); // Create a StreamReader to read the JSON data from the stream
        var json = reader.ReadToEnd(); // Read the entire JSON data as a string
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true }; // Set options to ignore case when matching property names


        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options); // Deserialize the JSON string into a FeatureCollection object using the specified options

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        var earthquakeDescriptions = new List<string>(); // List to hold the descriptions
        if (featureCollection?.Features == null)
        {
            return Array.Empty<string>(); // Return empty array if no features
        }
        foreach (var feature in featureCollection.Features)
        {
            var place = feature.Properties.Place; // Get the place of the earthquake
            if (string.IsNullOrEmpty(place))
            {
                continue; // Skip if place is null or empty
            }
            var magnitude = feature.Properties.Mag; // Get the magnitude of the earthquake
            if (magnitude < 0)
            {
                continue; // Skip if magnitude is negative
            }
            earthquakeDescriptions.Add($"{place} - Magnitude: {magnitude}"); // Create the description string
        }
        return earthquakeDescriptions.ToArray();
    }
}