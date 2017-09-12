What is it?
================================

Chinese spam filter for Office Outlook user.

Supported environments (Tested.)

    * Outlook 2016
    * .NET Framework 4.5.2 installed
    * Windows 10 or later

How to install
================================

Sorry for that I have no certificate from wellknown trusted issuer. So you have to download and install my private cert.

1) download at [http://sysnet.blob.core.windows.net/temp/stjeong.cer](http://sysnet.blob.core.windows.net/temp/stjeong.cer)
2) Install stjeong.cer to your PC.

```
Run cmd.exe with administration rights, then execute as follows.

C:\temp>certmgr.exe -add stjeong.cer -c -s -r localMachine Root

C:\temp>certmgr.exe -add stjeong.cer -c -s -r localMachine TrustedPublisher
```

3) Run setup at [http://sysnet.blob.core.windows.net/temp/office/setup.exe](http://sysnet.blob.core.windows.net/temp/office/setup.exe)



How to build
================================
If you want to make binaries from this project, just load and compile in Visual Studio 2017.


Change Log
================================

1.0.0.7 - Sep 13, 2017

* Initial checked-in (For Koreans, read [this article](http://www.sysnet.pe.kr/2/0/11306))


Reqeuests or Contributing to Repository
================================
If you need some features or whatever, make an issue at [https://github.com/stjeong/CharacterRangeFilter/issues](https://github.com/stjeong/CharacterRangeFilter/issues)

Any help and advices for this repo are welcome.

License
================================
Apache License V2.0

(Refer to LICENSE.txt)