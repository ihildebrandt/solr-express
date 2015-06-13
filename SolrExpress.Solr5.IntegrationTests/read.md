﻿## Steps to make this tests work:
1 - Access http://archive.apache.org/dist/lucene/solr/5.1.0/
2 - Download the solr-5.1.0.zip file
3 - Unzip the file in C:\Temp (or other folder of your preference)
4 - Make sure than all requirements of SOLR system was installed in the computer (basically, Java JRE 1.7+)
5 - Open the command prompt and than write the bellow commands:
	I	- cd C:\Temp\solr-5.1.0\bin
	II	- solr start -e techproducts -noprompt
6 - If the universe like you, all the things is right and you can access http://localhost:8983/solr/#/techproducts and start these tests :)
7 - To shutdown SOLR server, just open the command prompt and write the command "solr stop -all"