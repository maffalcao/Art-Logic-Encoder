using Encoder.Helpers;

namespace Encoder.BinaryMap;

public abstract class BinaryCryptographyBase
{
    protected virtual int MAX_INPUT_LENGHT => 0;
    protected const int BYTE_LENGTH = 8;
    protected const int TRANSFORMED_STRING_LENGHT = 4;

    abstract protected T FormatInput<T>(string input);


    // given an index 'i' from array 'origin', we want to map it to the corresponding index 'j' in array 'destiny'.
    // This way, is it possible to encode the string (array of chars) as destiny[j] = origin[i];
    // This operation is the encoding logic
    // 
    // Encoding logic:
    // - To encode the value in index 'i' from array 'origin' to array 'destiny', we calculate the index in array 'destiny' as:
    //   - 8 * (i % 4) + (i / 4).
    // This operation ensures that each index 'i' from array 'origin' maps to the corresponding index
    // in array 'destiny' based on the provided pattern.
    //
    // For example:
    // - When i = 0:
    //   - j: 8 * (0 % 4) + (0 / 4) = 8 * 0 + 0 = 0
    //   - So, the value at index 0 in array 'origin' is set to index 0 in array 'destiny'.
    //
    // - When i = 1:
    //   - Encoding: 8 * (1 % 4) + (1 / 4) = 8 * 1 + 0 = 8
    //   - So, the value at index 1 in array 'origin' is set to index 8 in array 'destiny'.
    //    
    //
    // To perform decoding, we only need to invert this operation
    // 
    // Decoding logic:
    // - Given an index 'j' from array 'destiny', we want to find its corresponding index in array 'origin'.
    // - We can get the index 'j' back to the original index 'i' in array 'origin' using the inverse operation:
    //   - i = (j % 8) * 4 + (j / 8).
    // This decoding operation inversely maps the index 'j' from array 'destiny' back to its original index 'i' in array 'origin'.

    protected string PerformMapping(CryptographyType actionType, string text)
    {
        try
        {
            char[] transformedString = new char[text.Length];

            // the way our encoding method map the index from input to the index of the output
            for (int i = 0; i < BYTE_LENGTH; i++)
            {
                for (int j = 0; j < TRANSFORMED_STRING_LENGHT; j++)
                {

                    (int iIndex, int jIndex) = GetMappingIndexes(i, j, actionType);

                    transformedString[iIndex] = text[jIndex];
                }
            }

            return new(transformedString);

        }
        catch (Exception exeption)
        {
            throw new Exception($"Something went wrong while encoding: {exeption.Message}");
        }
    }


    protected (int, int) GetMappingIndexes(int internalIndex, int externalIndex, CryptographyType actionType = CryptographyType.Encode)
    {
        /* 
            from the index 'i' from array 'origin' calculate the corresponding index in array 'destiny'
            according to the operation:

                encode: j = 8 * (i % 4) + (i / 4)
                decode: i = (j % 8) * 4 + (j / 8)
        */

        var mapInternalIndex = externalIndex + (TRANSFORMED_STRING_LENGHT * internalIndex);
        var mapExternalIndex = internalIndex + (BYTE_LENGTH * externalIndex);

        if (actionType == CryptographyType.Decode)
        {
            mapInternalIndex = internalIndex + (BYTE_LENGTH * externalIndex);
            mapExternalIndex = externalIndex + (TRANSFORMED_STRING_LENGHT * internalIndex);
        }

        return (mapInternalIndex, mapExternalIndex);
    }
}