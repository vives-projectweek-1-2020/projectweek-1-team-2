create database nursing_home1;
#-------------------------------
use nursing_home1;
#-------------------------------

create table people (
id int not null auto_increment,
name varchar(64),
last_name varchar(64),
email varchar(128) not null,
type enum('visitor', 'resident'),
temperature tinyint not null,
access bool not null,
primary key(id)
); 

#-----------------------------------------------

create table visits (
id int not null auto_increment,
visitor_id int not null,
resident_id int not null,
date_visit datetime default now(),
primary key(id),
foreign key (visitor_id) references people(id),
foreign key (resident_id) references people(id)
);
