USE FinShark;

INSERT INTO Stocks(Symbol,CompanyName,Purchase,LastDividend,Industry,MarketCap)
VALUES('AAPL','APPLE',10,1,'TECHNOLOGY',200000);

INSERT INTO Stocks(Symbol,CompanyName,Purchase,LastDividend,Industry,MarketCap)
VALUES('MSFT','MICROSOFT',20,2,'TECHNOLOGY',150000);

INSERT INTO Stocks(Symbol,CompanyName,Purchase,LastDividend,Industry,MarketCap)
VALUES('RPD','RAPIDO',20,1,'TRAVEL',2000);

INSERT INTO Stocks(Symbol,CompanyName,Purchase,LastDividend,Industry,MarketCap)
VALUES('ZMT','ZOMATO',30,2,'FOOD',5000);

SELECT * from Stocks

  INSERT INTO Comments(Title,Content,CreatedOn,StockId) VALUES('Apple','great product',SYSDATETIME(),1);
  INSERT INTO Comments(Title,Content,CreatedOn,StockId) VALUES('Microsoft','good software ',SYSDATETIME(),2);
  INSERT INTO Comments(Title,Content,CreatedOn,StockId) VALUES('Rapido','great cab service',SYSDATETIME(),3);
  INSERT INTO Comments(Title,Content,CreatedOn,StockId) VALUES('Zomato','great food chains',SYSDATETIME(),4);