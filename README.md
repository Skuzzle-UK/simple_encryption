# simple_encryption
## Simple encription class

Encryption that requires a unique identifier / passphrase provided during encryption and required to decrypt.

*Dont lose the identifier or you'll never get the data back.*

---
### Using class within another application
- Include class into your application.
- Pass data as a string by calling encrypt(data, identifier), returns a string of hexadecimal.
- Get data back by passing the encrypted hexstring through decrypt(hexstring, identifier), returns the data as a string.

---
### Standalone
Small console app is run via void main when compiled and executed, which can encrypt and decrypt using the algorithm.

Standalone encryption.exe is included to test out the app or just to use it in the most straight forward way possible.

*Release folder contains executable file*

---
### Ideas to play with encryption.exe
- Encrypt the phrase "Hello World" using identifier "password123". This will give the string "0033002300130046002700F60077003700370016000700430083000300030063005300030003006300340003000300630034000300030063006400030003002300030003000300530073000300030063006400030003007300230003000300630034000300030063004300030003"
- Decrypt it back to "Hello World".
- Open a .jpg file in notepad. Pass the data from that through encryption and overwrite the .jpg file with the new data. Then try converting back.
- Save your password list in a .txt file encrypted so that you can easily decrypt later, as long as you can remember the unique identifier that you used........
