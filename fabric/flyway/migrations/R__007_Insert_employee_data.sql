INSERT INTO operations.employee ("employee_id", "created_date", "updated_date", "last_name", "first_name", "title", "birth_date", "hire_date", "address", "city", "state", "country", "postal_code", "phone", "fax", "email") VALUES (1, NOW(), NOW(), 'Adams', 'Andrew', 'General Manager', '1962/2/18', '2002/8/14', '11120 Jasper Ave NW', 'Edmonton', 'AB', 'Canada', 'T5K 2N1', '+1 (780) 428-9482', '+1 (780) 428-3457', 'andrew@jukenookonline.com') ON CONFLICT DO NOTHING;
INSERT INTO operations.employee ("employee_id", "created_date", "updated_date", "last_name", "first_name", "title", "reports_to", "birth_date", "hire_date", "address", "city", "state", "country", "postal_code", "phone", "fax", "email") VALUES (2, NOW(), NOW(), 'Edwards', 'Nancy', 'Sales Manager', 1, '1958/12/8', '2002/5/1', '825 8 Ave SW', 'Calgary', 'AB', 'Canada', 'T2P 2T3', '+1 (403) 262-3443', '+1 (403) 262-3322', 'nancy@jukenookonline.com') ON CONFLICT DO NOTHING;
INSERT INTO operations.employee ("employee_id", "created_date", "updated_date", "last_name", "first_name", "title", "reports_to", "birth_date", "hire_date", "address", "city", "state", "country", "postal_code", "phone", "fax", "email") VALUES (3, NOW(), NOW(), 'Peacock', 'Jane', 'Sales Support Agent', 2, '1973/8/29', '2002/4/1', '1111 6 Ave SW', 'Calgary', 'AB', 'Canada', 'T2P 5M5', '+1 (403) 262-3443', '+1 (403) 262-6712', 'jane@jukenookonline.com') ON CONFLICT DO NOTHING;
INSERT INTO operations.employee ("employee_id", "created_date", "updated_date", "last_name", "first_name", "title", "reports_to", "birth_date", "hire_date", "address", "city", "state", "country", "postal_code", "phone", "fax", "email") VALUES (4, NOW(), NOW(), 'Park', 'Margaret', 'Sales Support Agent', 2, '1947/9/19', '2003/5/3', '683 10 Street SW', 'Calgary', 'AB', 'Canada', 'T2P 5G3', '+1 (403) 263-4423', '+1 (403) 263-4289', 'margaret@jukenookonline.com') ON CONFLICT DO NOTHING;
INSERT INTO operations.employee ("employee_id", "created_date", "updated_date", "last_name", "first_name", "title", "reports_to", "birth_date", "hire_date", "address", "city", "state", "country", "postal_code", "phone", "fax", "email") VALUES (5, NOW(), NOW(), 'Johnson', 'Steve', 'Sales Support Agent', 2, '1965/3/3', '2003/10/17', '7727B 41 Ave', 'Calgary', 'AB', 'Canada', 'T3B 1Y7', '1 (780) 836-9987', '1 (780) 836-9543', 'steve@jukenookonline.com') ON CONFLICT DO NOTHING;
INSERT INTO operations.employee ("employee_id", "created_date", "updated_date", "last_name", "first_name", "title", "reports_to", "birth_date", "hire_date", "address", "city", "state", "country", "postal_code", "phone", "fax", "email") VALUES (6, NOW(), NOW(), 'Mitchell', 'Michael', 'IT Manager', 1, '1973/7/1', '2003/10/17', '5827 Bowness Road NW', 'Calgary', 'AB', 'Canada', 'T3B 0C5', '+1 (403) 246-9887', '+1 (403) 246-9899', 'michael@jukenookonline.com') ON CONFLICT DO NOTHING;
INSERT INTO operations.employee ("employee_id", "created_date", "updated_date", "last_name", "first_name", "title", "reports_to", "birth_date", "hire_date", "address", "city", "state", "country", "postal_code", "phone", "fax", "email") VALUES (7, NOW(), NOW(), 'King', 'Robert', 'IT Staff', 6, '1970/5/29', '2004/1/2', '590 Columbia Boulevard West', 'Lethbridge', 'AB', 'Canada', 'T1K 5N8', '+1 (403) 456-9986', '+1 (403) 456-8485', 'robert@jukenookonline.com') ON CONFLICT DO NOTHING;
INSERT INTO operations.employee ("employee_id", "created_date", "updated_date", "last_name", "first_name", "title", "reports_to", "birth_date", "hire_date", "address", "city", "state", "country", "postal_code", "phone", "fax", "email") VALUES (8, NOW(), NOW(), 'Callahan', 'Laura', 'IT Staff', 6, '1968/1/9', '2004/3/4', '923 7 ST NW', 'Lethbridge', 'AB', 'Canada', 'T1H 1Y8', '+1 (403) 467-3351', '+1 (403) 467-8772', 'laura@jukenookonline.com') ON CONFLICT DO NOTHING;

ALTER TABLE operations.employee
ALTER COLUMN employee_id ADD GENERATED ALWAYS AS IDENTITY;

ALTER TABLE operations.employee ALTER COLUMN employee_id RESTART WITH 1000;