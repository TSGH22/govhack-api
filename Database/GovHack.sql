SELECT *
FROM Properties;

DELETE
FROM Properties
WHERE Id IS NOT NULL;


SELECT *
FROM Location;

UPDATE Location
SET
    Latitude = -33.868563,
    Longitude = 151.179171
WHERE Id IS NOT NULL

UPDATE Location
    SET
        Suburb = "Surry Hills"
WHERE Suburb = ""

UPDATE Properties
    SET Description = 'Over two levels, with an open void that creates one cohesive space. On level one there is a pleasant indoor/outdoor kitchen and communal dining area, providing a united focus for your organisation.'
WHERE ID IS NOT NULL
