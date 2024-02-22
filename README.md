## Project Readme

## [**BitEncryptor**](https://github.com/maffalcao/BitEncryptor)

The strategy used to encode and decode a string is based on the technique of mapping the index in the source array to the index in the destination array.

  
**For encoding a string**

In the **Encode** method, after formatting the input, it is converted to its binary format representation. Then comes the crucial step of index mapping, where each character in the binary representation is mapped to a new index in the destination array using a specific cryptography technique. This results in the encoded string. Finally, the encoded string is converted to a specific format before being returned.

**For decoding a string**

In the **Decode** method, the input number is formatted as needed. The encoded string is reversed to its original binary representation. Then, the index mapping step occurs again, but this time using the inverse operation of the cryptography technique used in encoding. This results in the binary representation of the original string. Finally, the binary representation is reversed to its original text form before being returned, and any non-printable characters are removed.

This index mapping approach is crucial to ensure that encoding and decoding occur consistently and reversibly.

**Mapping index strategy to deconding**

Given an index 'i' from array 'origin', we want to map it to the corresponding index 'j' in array 'destiny'. This allows us to encode the string (array of characters) by setting 'destiny\[j\] = origin\[i\]'.

The encoding operation follows this logic:

j = 8 \* (i % 4) + (i / 4)

This operation ensures that each index 'i' from array 'origin' maps to the corresponding index in array 'destiny' based on the provided pattern.

For example:

*   When i = 0, j = 0.
*   When i = 1, j = 8.

**Mapping index strategy to decoding**

To perform decoding, we need to invert the encoding operation. Given an index 'j' from array 'destiny', we want to find its corresponding index in array 'origin'.

The decoding operation follows this logic:

i = (j % 8) \* 4 + (j / 8)

---

### Getting Started

1.  **Install .NET SDK 8:** Make sure you have .NET SDK 8 installed on your machine. You can download it from [Microsoft's official website](https://dotnet.microsoft.com/download/dotnet/8.0).
2.  **Navigate to the project folder:**
    
    ```plaintext
    cd Cryptography
    ```
    
3.  **Run the Encoder:**  
    Use the following command to encode your text:
    
    ```plaintext
    dotnet run -e  "<textToBeEncoded>"
    
    example: dotnet run -e "lager, sir, is regal"
    ```
    
4.  **Run the Decoder:**  
    Use the following command to decode your text:
    
    ```plaintext
    to encode: dotnet run -e  "<textToBeDecoded>"
    
    example: dotnet run -d "[267394382, 167322264, 66212897, 200937635, 267422503]"
    ```
    

#### **Encoding Commands and Results:**

**dotnet run -e tacocat**
Result: **\[267487694, 125043731\]**

**dotnet run -e "never odd or even"**
Result: **\[267657050, 233917524, 234374596, 250875466, 17830160\]**

**dotnet run -e "lager, sir, is regal"** 
Result: **\[267394382, 167322264, 66212897, 200937635, 267422503\]**

**dotnet run -e "go hang a salami, I'm a lasagna hog"** 
Result: **\[200319795, 133178981, 234094669, 267441422, 78666124, 99619077, 267653454, 133178165, 124794470\]**

Command: **dotnet run -e "egad, a base tone denotes a bad age"** 
Result: **\[267389735, 82841860, 267651166, 250793668, 233835785, 267665210, 99680277, 133170194, 124782119\]**

#### **Decoding Commands and Results:**

**dotnet run -d "[267487694 125043731]"** 
Result: **tacocat**

**dotnet run -d "[267657050 233917524 234374596 250875466 17830160]"** 
Result: **never odd or even**

**dotnet run -d "[267394382 167322264 66212897 200937635 267422503]"**
Result: **lager, sir, is regal**

**dotnet run -d "[200319795 133178981 234094669 267441422 78666124 99619077 267653454 133178165 124794470]"** 
Result: **go hang a salami, I'm a lasagna hog**

**dotnet run -d "[267389735 82841860 267651166 250793668 233835785 267665210 99680277 133170194 124782119]"** Result: **egad, a base tone denotes a bad age**

### **Testing the application**

1.  **Navigate to the test folder:**
    
    ```plaintext
    cd Tests
    ```
    
2.  **Run the tests:**
    
    ```plaintext
    dotnet test
    ```
