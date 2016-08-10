/*
This is the demo file for the chapter on SQL in The Imposter's Handbook.
It's set up specifically for PostgreSQL, so if you try it on MySQL or SQL Server
you might have issues...
*/


--just create a simple table
create table users(id int, name varchar(50));

--drop the table
drop table users;

--create with a PK
create table users(
    id serial primary key
);

--drop it again
drop table users;

--OK create it again but with an email and constraint
create table users(
    id serial primary key,
    email varchar(50) not null unique
);

--drop again
drop table users;

--create with more constraints
create table users(
    id serial primary key,
    email varchar(50) not null unique,
    created_at timestamptz not null default now(),
    updated_at timestamptz
);

--again!

drop table if exists users;
create table users(
    id serial primary key,
    email varchar(50) not null unique,
    name varchar(50),
    created_at timestamptz not null default now(),
    updated_at timestamptz
);

-- insert some data
insert into users(email, name)
values('test@example.com','Test User');

--more data... but this will error
insert into users(email, name)
values('test@example.com','Test User')
returning id;

--fix the error
insert into users(email, name)
values('test2@example.com','Another Test User')
returning id;

-- insert a set of data in a transaction
-- we'll ban all of our users and implode our company
BEGIN;
create table banned_users(
    id int primary key,
    email varchar(50) not null unique,
    name varchar(50)
);
insert into banned_users(id, email, name)
select id, email, name from users;
COMMIT;

--more sets
insert into users(email, name) values
('test3@example.com','Test User 3'),
('test4@example.com','Test User 4'),
('test5@example.com','Test User 5')
returning *;

--OK let them back in
drop table banned_users;

-- delete them ALL!
delete from users;

-- OK just a few of them
delete from users
where id > 5;

-- Put them back again
insert into users(email, name) values
('test3@example.com','Test User 3'),
('test4@example.com','Test User 4'),
('test5@example.com','Test User 5')
returning *;

-- update user 7's name
update users
set name='Test User 7'
where id=7;


-- use some groovy SQL-fu
update users set
name='Test User ' || id::varchar(3),
email='test' || id::varchar(3) || '@example.com'
returning *;

-- same thing, but with some style
update users set
name=concat('Test User ',id),
email=concat('test ',id,'@example.com')
returning *;

-- use a where clause
update users set
name=concat('Test User ',id),
email=concat('test',id,'@example.com')
where id > 5
returning *;

-- SELECTs and reading data
select * from users;

-- just one column
select email from users;

-- with an alias/computed column
select email, name,
concat('<',email,'> ',name) as full_email
from users;

-- basic where clauses
select * from users
where id=7;

select * from users
where id > 7;

select * from users
where id between 7 and 9;

select * from users
where id in(7,9);

-- written in a different way
select * from users
where id > 6
and id < 10; --similar to between 7 and 9

select * from users
where id = 7
or id = 9; --similar to in(7,9)

-- partial matching with LIKE and ILIKE
select * from users
where email like '%example.com';

-- REGEX
select * from users
where email ~ 'example.com';

-- complex ORs
select * from users
where id > 6
and id < 8
or id = 9;

-- more complexity
select * from users
where id > 6
and id < 8
or id = 9
or id = 6;

-- bahahahahaha
select * from users
where (id = 6 or id = 9)
and id = 8;

-- ordering
select * from users
where id > 6
and id < 8
or id = 9
order by id;

-- descending order
select * from users
order by created_at DESC, name;

-- limiting
select * from users
order by created_at DESC, name
limit 1;


-- limit and offset
select * from users
order by created_at DESC, name
limit 1 offset 1;

-- paging
select * from users
order by created_at DESC, name
limit 20 offset 40; --page 3

-- aggregates
select count(1) from users;

-- more
select sum(id) from users;
select avg(id) from users;
select min(id) from users;
select max(id) from users;

-- let's make an error
select avg(id), email from users
where id > 1;

-- solve it with GROUP BY
select avg(id), email from users
where id > 1
group by id, email;

-- let's make another error using a WHERE clause
select avg(id), email from users
where avg(id) > 7
group by id, email
order by avg(id) desc;

-- and we solve it with HAVING
select avg(id), email from users
group by id, email
having avg(id) > 7
order by avg(id) desc;

-- create a new table we can JOIN on
create table addresses(
  id serial primary key,
  user_id int not null references users(id),
  street varchar(50) not null,
  city varchar(50) not null,
  state char(2) not null,
  country char(2) not null,
  zip varchar(12) not null
);

-- add an address to our user. make sure you have a user with the right id here
insert into addresses(user_id, street, city, state, country, zip)
values(8, '10 test street', 'Anywhere', 'CA', 'US', '00000');

-- inner join
select email, city, state
from users
inner join addresses on addresses.user_id = users.id;

-- let's cause an error
select id, email, city, state
from users
inner join addresses on addresses.user_id = users.id;

-- we'll fix the error now...
select users.id, email, city, state
from users
inner join addresses on addresses.user_id = users.id;

-- aliasing and qualifying names
select u.id, u.email, a.city, a.state
from users u
inner join addresses a on a.user_id = u.id;

-- a left outer join
select users.id, email, city, state
from users
left join addresses on addresses.user_id = users.id;

-- switching table positions
select users.id, email, city, state
from addresses
left join users on addresses.user_id = users.id;

-- using a right join
select users.id, email, city, state
from users
right join addresses on addresses.user_id = users.id;

-- alerting our table to add a column
alter table users add referred_by_id int;

-- update our user to have a referral
update users
set referred_by_id = 7
where id = 8;

-- run a self-join
select users.id, users.email, referrers.email as referred_by
from users
inner join users referrers on referrers.id = users.referred_by_id;

-- show all users regardless of referrals
select users.id, users.email, referrers.email as referred_by
from users
left join users referrers on referrers.id = users.referred_by_id;


