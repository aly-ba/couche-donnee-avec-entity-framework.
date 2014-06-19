ALTER TABLE phone_number ADD CONSTRAINT FK_phone_number_person FOREIN KEY (phone_number_id)
REFERENCES person(person_id);

