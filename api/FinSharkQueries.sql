USE FinShark;

INSERT INTO Stocks(Symbol,CompanyName,Purchase,LastDividend,Industry,MarketCap)
VALUES('AAPL','APPLE',10,1,'TECHNOLOGY',200000);

INSERT INTO Stocks(Symbol,CompanyName,Purchase,LastDividend,Industry,MarketCap)
VALUES('MSFT','MICROSOFT',20,2,'TECHNOLOGY',150000);

SELECT * from Stocks