CREATE TABLE IF NOT EXISTS accounts
(
	id INT AUTO_INCREMENT PRIMARY KEY,
    number INT UNIQUE NOT NULL,
    value decimal NOT NULL DEFAULT 0
)

CREATE TABLE IF NOT EXISTS transactions
(
	id INT AUTO_INCREMENT PRIMARY KEY,
    accountNumber INT NOT NULL,
    transactionType INT NOT NULL,
    transactionValue DECIMAL NOT NULL,
    transactionTime datetime NOT NULL
);

ALTER TABLE transactions ADD CONSTRAINT fk_account_transactions FOREIGN KEY (accountNumber) REFERENCES accounts (number);

insert into accounts (number,value) values (12345678,150);
insert into accounts (number,value) values (87654321,250);
insert into accounts (number,value) values (14725836,100);
insert into accounts (number,value) values (74185263,500);
insert into accounts (number,value) values (32165487,550);
