import sqlite3
import sys

#Get database name from argument
if(len(sys.argv) < 2): 
	print("Need a database file name.")
	sys.exit(0)

dbName = sys.argv[1]

#connect to sqlite database
con = sqlite3.connect(dbName)

with con:
	c = con.cursor()

	#Create tables
	
	#FullZipExceptions table for FullZip exceptions
	c.execute('CREATE TABLE FullZipExceptions( ID INTEGER PRIMARY KEY, fullZip INTEGER UNIQUE, sort TEXT)')
	#4DigitExceptions table for Human Readable execptions requiring 4th digit
	c.execute('CREATE TABLE [4DigitExceptions](ID INTEGER PRIMARY KEY, HR INTEGER, [4thDigit] INTEGER, sort TEXT)')
	#HR table for normal HR(Human Readable) labels
	c.execute('CREATE TABLE HR(ID INTEGER PRIMARY KEY, HR INTEGER UNIQUE, sort TEXT)')
	#3Day table for 3Day packages
	c.execute('CREATE TABLE [3Day](ID INTEGER PRIMARY KEY, HR INTEGER UNIQUE, sort TEXT)')
	#3Day table for 2Day packages
	c.execute('CREATE TABLE [2Day](ID INTEGER PRIMARY KEY, HR INTEGER UNIQUE, sort TEXT)')
	#NextDay table for NextDay packages
	c.execute('CREATE TABLE NextDay(ID INTEGER PRIMARY KEY, HR INTEGER UNIQUE, sort TEXT)')


con.commit()
con.close()