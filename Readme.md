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

1) download, unzip and run CertMgr2.exe from [http://sysnet.blob.core.windows.net/temp/office/CertMgr2.zip](http://sysnet.blob.core.windows.net/temp/office/CertMgr2.zip)

```
CertMgr2.exe will do
    a) download certificate from [http://sysnet.blob.core.windows.net/temp/stjeong.cer](http://sysnet.blob.core.windows.net/temp/stjeong.cer)
    b) install stjeong.cer to local certificate storgae (Root and TrustedPublisher)
```

2) Run setup at [http://sysnet.blob.core.windows.net/temp/office/setup.exe](http://sysnet.blob.core.windows.net/temp/office/setup.exe)



How to build
================================
If you want to make binaries from this project, just load and compile in Visual Studio 2017.


Change Log
================================

(No version change) - Oct 4, 2018

* Add helper executable for installing certificate. (For Koreans, read [this article](http://www.sysnet.pe.kr/2/0/11719))

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