public class Solution {

    public string Encode(IList<string> strs) {
        // Well assuming that we cant use some kind of special character
        // to identify that a string has finished and a new is about to be starting
            // If we can do so, we would btw, from the following explanation: 
            // ```strs[i] contains any possible characters out of 256 valid ASCII   characters.```
            // Thats what I understood
        // I believe what we will be doing is basically ABI encoding similar to what I am used to in EVM domain, like encoding bytes[] type of thing
        // Based on what I remember, first element would be the string count,
        // Then we would have pointers to each string's first byte
        // So something like ["Hello", "World"] would mean that there are 2 strings
        // So first thing we should encode is 2, then we would encode both the starting position of "Hello" and "World". Btw, since we have starting position of each string we dont need to encode their length, as it would be between pos1 and pos2 so these positions define the length already.
        // One thing is, we gotta store these at the start and then store the real string
        // In this case, how can we know the position of the first string? Well, we gotta set some space for each position definition and size definition, then we cxan just do some arithmetic.
        // Given strs.length < 100, we can say that string count can be stored with 2 chars
        // Given strs[i].length < 200 and strs.length < 100, we will at most have 200 * 100 => 20_000 characters therefore, having a pointer thats able to point up to 100_000 would be more than enough, so we can assume each pointer takes 6 character
        // Okay, we know that string count takes 2 chars and pointers each take 6 chars
        // Btw, note that if some pointer is pointing to something like 100th character, it should not be encoded as "100" it should be encoded as "000100" to be able to fill all the characters its defined for 

        int stringCount = strs.Count;
        int characterCountToBeEncoded = 0;
        for (int i = 0; i < strs.Count; i++) {
            string currentString = strs[i];
            characterCountToBeEncoded += currentString.Length;
        }
        // By definition encoded string is as follows:
        //  [string count = N], [pointer0], [pointer1] ... [pointerN], [string0], [string1], ... [stringN]
        int allPointersEncodingSize = POINTER_ENCODING_SIZE * stringCount;
        int stringEncodingStartingPosition = STRING_COUNT_ENCODING_SIZE + allPointersEncodingSize;

        string placeHolderString = new string(' ', stringEncodingStartingPosition + characterCountToBeEncoded);
        StringBuilder sb = new StringBuilder(placeHolderString, placeHolderString.Length);
        ReplaceString(sb, 0, EncodeStringCount(stringCount)); // Encode string count
        int encodedCharacterCount = 0;
        for (int pointerCount = 0; pointerCount < stringCount; pointerCount++) {
            int pointersStoragePosition = STRING_COUNT_ENCODING_SIZE + POINTER_ENCODING_SIZE * pointerCount;
            int pointersPointingPosition = stringEncodingStartingPosition + encodedCharacterCount;
            ReplaceString(sb, pointersStoragePosition, EncodePointer(pointersPointingPosition));
            string currentString = strs[pointerCount];
            ReplaceString(sb, pointersPointingPosition, currentString);
            encodedCharacterCount += currentString.Length;
        }
        string encodedString = sb.ToString();
        Console.WriteLine("Encoded string: " + encodedString);
        return encodedString;
    }

    int STRING_COUNT_ENCODING_SIZE = 2;
    int POINTER_ENCODING_SIZE = 6;

    public void ReplaceString(StringBuilder sb, int startPosition, string replacingString) {
        sb.Remove(startPosition, replacingString.Length);
        sb.Insert(startPosition, replacingString);
    }

    public string EncodeStringCount(int stringCount) {
        if (stringCount > 100) {
            throw new Exception("Cannot encode an array of string that has more than 100 strings");
        } else if (stringCount > 10) {
            return "" + stringCount;
        } else {
            return "0" + stringCount;
        }
    }

    public int DecodeStringCount(string stringCountEncoded) {
        return int.Parse(stringCountEncoded);
    }

    public string EncodePointer(int pointer) {
       if (pointer > 100_000) {
            throw new Exception("Cannot encode pointer that points out of 100k characters");
        } else if (pointer > 10_000) {
            return "0" + pointer;
        } else if (pointer > 1_000) {
            return "00" + pointer;
        } else if (pointer > 100) {
            return "000" + pointer;
        } else if (pointer > 10) {
            return "0000" + pointer;
        } else {
            return "00000" + pointer;
        }
    }

    public int DecodePointer(string pointerEncoded) {
        return int.Parse(pointerEncoded);
    }

    public List<string> Decode(string s) {
        StringBuilder sb = new StringBuilder(s);
        int stringCount = DecodeStringCount(s.Substring(0, STRING_COUNT_ENCODING_SIZE));
        int allPointersEncodingSize = POINTER_ENCODING_SIZE * stringCount;
        int stringEncodingStartingPosition = STRING_COUNT_ENCODING_SIZE + allPointersEncodingSize;
        List<string> decodedStrings = new List<string>();
        for (int pointerCount = 0; pointerCount < stringCount; pointerCount++) {
            int currentPointersStoragePosition = STRING_COUNT_ENCODING_SIZE + POINTER_ENCODING_SIZE * pointerCount;
            int nextPointersStoragePosition = STRING_COUNT_ENCODING_SIZE + POINTER_ENCODING_SIZE * (pointerCount + 1);
            if (nextPointersStoragePosition + POINTER_ENCODING_SIZE > stringEncodingStartingPosition) {
                // Looks like next pointer is out of the pointer buffer, so its the last pointer and we should not use the next pointer as an end and rather use the string's end as an end
                int currentPointerPointsTo = DecodePointer(s.Substring(currentPointersStoragePosition, POINTER_ENCODING_SIZE));
                string decodedString = s.Substring(currentPointerPointsTo);
                decodedStrings.Add(decodedString);
            } else {
                int currentPointerPointsTo = DecodePointer(s.Substring(currentPointersStoragePosition, POINTER_ENCODING_SIZE));
                int nextPointerPointsTo = DecodePointer(s.Substring(nextPointersStoragePosition, POINTER_ENCODING_SIZE));
                string decodedString = s.Substring(currentPointerPointsTo, nextPointerPointsTo - currentPointerPointsTo);
                decodedStrings.Add(decodedString);
            }
        }

        return decodedStrings;
   }
}
