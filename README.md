# simple_encryption
Simple encription class

Encryption requires a unique identifier / passphrase provided during encryption and required to decrypt.
Dont lose the identifier or you'll never get the data back.

Pass data as a string by calling encrypt(data, identifier), returns a string of hexadecimal.
Get data back by passing the encrypted hexstring through decrypt(hexstring, identifier), returns the data as a string.

Can be run via 
