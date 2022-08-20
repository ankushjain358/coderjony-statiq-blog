Title: Difference between ASCII & Unicode Character Sets
Published: 12/11/2018
Author: Ankush Jain
IsActive: true
ImageFolder: difference-between-ascii-unicode-character-sets
Tags:
  - Encoding
  - Cryptography
---
ASCII & Unicode both are character sets & both character sets (ASCII & Unicode) hold a list of characters with unique decimal numbers (code points). A= 65, B=66, C=67 etc.

## ASCII
ASCII stands for American Standards Codes for Information Interchange.

ASCII character set contains 128 characters. Each number from 0 to 127 represents a character. 

These 128 ASCII characters covers all Numeric numbers from (0-9), English alphabets upper case (A-Z), English alphabets lower case (a-z) & some other non-alphanumeric characters (~, ! , @, #, $, %, ^, &, *, (, ), _, ~, -, <, >, ?, /, . Etc.)

Each character, mentioned above has its own decimal value. For example, capital alphabets A-Z has a decimal value from 65 to 90, and small alphabets a-z has their decimal value from 97-122.

> ASCII defines 128 characters, which map to the numbers 0–127. To represent a character of this range, ASCII requires only 7 bit.

Since, in Computer Science, the size of 1 byte equals 8 bits. It means we can represent 0 to 255 characters using one byte. Though all of our characters have been covered in 7 bits & we are left with one more extra bit. To utilize this extra bit, Extended ASCII Characters come into the picture.

The range of Extended ASCII Characters is 128 to 255. [Click here to view the complete table of Extended ASCII characters](https://www.oreilly.com/library/view/the-secret-life/9781457182334/apcs03.xhtml).

## Unicode

There are lots of characters in the world, which may include various symbols, and various language characters like Hindi, Urdu, Chinese, Arabic etc. Emoji characters that we currently use in social networking apps & a lot of other symbols which we might not even be aware of. 

> Unicode defines `2^21` characters, which, similarly, map to numbers `0 - 2^21`. Though not all numbers are currently assigned. Some are free and some are reserved for future use.

It is said ([As per Wikipedia](https://en.wikipedia.org/wiki/Code_point)), at present, Unicode defines 1,114,112 code positions. Almost 100,000 have been currently allocated & the rest are free or reserved for future use. 

Though; its range is 2^21, it doesn't mean that we require only 21 bits to represent a Unicode character. To represent a Unicode character, the computer system uses Encoding. Hence the size of a Unicode character may differ from one Encoding scheme to another.

1.  UTF-8 (1 Byte to 4 Byte)
2.  UTF-16 (2 Byte or  4 Byte)
3.  UTF-32 ( 4 Byte)

This [link](https://stackoverflow.com/questions/5290182/how-many-bytes-does-one-unicode-character-take#answer-39181061) may help you regarding the size of Unicode characters.

**References:**
* [Character encoding](https://en.wikipedia.org/wiki/Character_encoding)
* [How do I set a SQL Server Unicode / NVARCHAR string to an emoji or Supplementary Character?](https://dba.stackexchange.com/questions/139551/how-do-i-set-a-sql-server-unicode-nvarchar-string-to-an-emoji-or-supplementary#answer-139568)
* [Unicode and .NET](http://csharpindepth.com/Articles/General/Unicode.aspx)
* [Why UTF-32 exists whereas only 21 bits are necessary to encode every character?](https://stackoverflow.com/questions/6339756/why-utf-32-exists-whereas-only-21-bits-are-necessary-to-encode-every-character)


                
