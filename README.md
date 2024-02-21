## Project Readme

## [**BitEncryptor**](https://github.com/maffalcao/BitEncryptor)

This project is designed to encode/decode text using a binary strategy.

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

1.  Command: **dotnet run -e tacocat** Result: **\[267487694, 125043731\]**
2.  Command: **dotnet run -e "never odd or even"** Result: **\[267657050, 233917524, 234374596, 250875466, 17830160\]**
3.  Command: **dotnet run -e "lager, sir, is regal"** Result: **\[267394382, 167322264, 66212897, 200937635, 267422503\]**
4.  Command: **dotnet run -e "go hang a salami, I'm a lasagna hog"** Result: **\[200319795, 133178981, 234094669, 267441422, 78666124, 99619077, 267653454, 133178165, 124794470\]**
5.  Command: **dotnet run -e "egad, a base tone denotes a bad age"** Result: **\[267389735, 82841860, 267651166, 250793668, 233835785, 267665210, 99680277, 133170194, 124782119\]**

#### **Decoding Commands and Results:**

1.  Command: **dotnet run -d 267487694 125043731** Result: **tacocat**
2.  Command: **dotnet run -d 267657050 233917524 234374596 250875466 17830160** Result: **never odd or even**
3.  Command: **dotnet run -d 267394382 167322264 66212897 200937635 267422503** Result: **lager, sir, is regal**
4.  Command: **dotnet run -d 200319795 133178981 234094669 267441422 78666124 99619077 267653454 133178165 124794470** Result: **go hang a salami, I'm a lasagna hog**
5.  Command: **dotnet run -d 267389735 82841860 267651166 250793668 233835785 267665210 99680277 133170194 124782119** Result: **egad, a base tone denotes a bad age**

### **Testing the application**

1.  **Navigate to the test folder:**
    
    ```plaintext
    cd Tests
    ```
    
2.  **Run the tests:**
    
    ```plaintext
    dotnet test
    ```