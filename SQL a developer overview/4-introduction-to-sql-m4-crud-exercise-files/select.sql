use Contacts;
select a.address_locality, a.address_city, a.address_state_province_county From 
address a where a.address_locality IS  Null;
select a.address_locality, a.address_city, a.address_state_province_county From 
address a where a.address_locality IS not Null;

select p.person_first_name, p.person_contacted_number From person p where p.person_first_name IN('Jon' ,'Shanon');
select p.person_first_name, p.person_contacted_number From person p where p.person_contacted_number IN(0,1);
select p.person_first_name From person p Where p.person_first_name like 
'%o%';
 select p.person_first_name From person p where p.person_first_name LIKE '%n';
select p.person_first_name From person p where p.person_first_name LIKE 'J%';
 select p.person_first_name, p.person_contacted_number from  person p
 where p.person_contacted_number Between 0 and 4;
 select p.person_first_name, p.person_contacted_number FROM person p where
 p.person_contacted_number BETWEEN 0 ANd 4;
select a.address_city, a.address_state_province_county from address a; 
select a.address_city, a.address_state_province_county from address a where a.address_city ='Los Angeles' OR
a.address_state_province_county ='California';
select a.address_city, a.address_state_province_county from address a where a.address_city ='Los Angeles' AND  
a.address_state_province_county ='California';
select a.address_city, a.address_state_province_county From address a;
