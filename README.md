## [**BitEncryptor**](https://github.com/maffalcao/BitEncryptor)

The strategy used to encode and decode a string is based on the technique of mapping the index in the source array to the index in the destination array.

### **For encoding a string**

In the **Encode** method, after formatting the input, it is converted to its binary format representation. Then comes the crucial step of index mapping, where each character in the binary representation is mapped to a new index in the destination array using a specific cryptography technique. This results in the encoded string. Finally, the encoded string is converted to a specific format before being returned.

### **For decoding a string**

In the **Decode** method, the input number is formatted as needed. The encoded string is reversed to its original binary representation. Then, the index mapping step occurs again, but this time using the inverse operation of the cryptography technique used in encoding. This results in the binary representation of the original string. Finally, the binary representation is reversed to its original text form before being returned, and any non-printable characters are removed.

This index mapping approach is crucial to ensure that encoding and decoding occur consistently and reversibly.

### **Mapping index strategy to deconding**

Given an index 'i' from array 'origin', we want to map it to the corresponding index 'j' in array 'destiny'. This allows us to encode the string (array of characters) by setting 'destiny\[j\] = origin\[i\]'.

The encoding operation follows this logic:

`j = 8 * (i % 4) + (i / 4)`

This operation ensures that each index 'i' from array 'origin' maps to the corresponding index in array 'destiny' based on the provided pattern.

For example:

*   When i = 0, j = 0.
*   When i = 1, j = 8.

### **Mapping index strategy to decoding**

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
    
    example: 
    
    dotnet run -e "lager, sir, is regal"
    Result: [267394382, 167322264, 66212897, 200937635, 267422503]
    ```
    
4.  **Run the Decoder:**  
    Use the following command to decode your text:
    
    ```plaintext
    to encode: dotnet run -e  "<textToBeDecoded>"
    
    example: 
    
    dotnet run -d "[267394382 167322264 66212897 200937635 267422503]"
    Result: lager, sir, is regal
    ```
    

---

### **Testing the application**

1.  **Navigate to the test folder:**
    
    ```plaintext
    cd Tests
    ```
    
2.  **Run the tests:**
    
    ```plaintext
    dotnet test
    ```
