DROP DATABASE IF EXISTS prueba4;
CREATE DATABASE prueba4;
USE prueba4;

DROP TABLE IF EXISTS species;
CREATE TABLE species
(
	num INT PRIMARY KEY,	# Número
    nombre VARCHAR(25),		# Nombre
    capRatio INT,		# Ratio de captura
    sexRatio FLOAT(10),		# Ratio de sexo
    bhp INT,			# Salud base
    color VARCHAR(25),		# Color
    atk INT,			# Ataque
    def INT,			# Defensa
    atkS INT,			# Ataque especial
    defS INT,			# Defensa especial
    speed INT,			# Velocidad
    weight FLOAT(10),		# Peso
    height FLOAT(10)		# Altura
);

INSERT INTO species VALUES (0, "Bulbasaur", 45, 0.125, 45, "Verde", 49, 49, 65, 65, 45, 6.9, 0.7);
INSERT INTO species VALUES (1, "Ivysaur", 45, 0.125, 60, "Verde", 62, 63, 80, 80, 60, 13.0, 1.0);
INSERT INTO species VALUES (2, "Venusaur", 45, 0.125, 80, "Verde", 82, 83, 100, 100, 80, 100.0, 2.0);
INSERT INTO species VALUES (3, "Charmander", 45, 0.125, 39, "Rojo", 52, 43, 60, 50, 65, 8.5, 0.6);
INSERT INTO species VALUES (4, "Charmeleon", 45, 0.125, 58, "Rojo", 64, 58, 80, 65, 80, 19.0, 1.1);
INSERT INTO species VALUES (5, "Charizard", 45, 0.125, 78, "Rojo", 84, 78, 109, 85, 100, 90.5, 1.7);
INSERT INTO species VALUES (6, "Squirtle", 45, 0.125, 44, "Azul", 48, 65, 50, 64, 43, 9.0, 0.5);
INSERT INTO species VALUES (7, "Wartortle", 45, 0.125, 59, "Azul", 63, 80, 65, 80, 58, 22.5, 1.0);
INSERT INTO species VALUES (8, "Blastoise", 45, 0.125, 79, "Azul", 83, 100, 85, 105, 78, 85.5, 1.6);
INSERT INTO species VALUES (9, "Caterpie", 255, 0.5, 45, "Verde", 30, 35, 20, 20, 45, 2.9, 0.3);
INSERT INTO species VALUES (10, "Metapod", 120, 0.5, 50, "Verde", 20, 55, 25, 25, 30, 9.9, 0.7);
INSERT INTO species VALUES (11, "Butterfry", 45, 0.5, 60, "Blanco", 45, 50, 90, 80, 70, 32.0, 1.1);
INSERT INTO species VALUES (12, "Weedle", 255, 0.5, 40, "Marrón", 35, 30, 20, 20, 50, 3.2, 0.3);
INSERT INTO species VALUES (13, "Kakuna", 120, 0.5, 45, "Amarillo", 25, 50, 25, 25, 35, 10.0, 0.6);
INSERT INTO species VALUES (14, "Beedrill", 45, 0.5, 65, "Amarillo", 90, 40, 45, 80, 75, 29.5, 1.0);
INSERT INTO species VALUES (15, "Pidgey", 255, 0.5, 40, "Marrón", 45, 40, 35, 35, 56, 1.8, 0.3);
INSERT INTO species VALUES (16, "Pidgeotto", 120, 0.5, 63, "Marrón", 60, 55, 50, 50, 71, 30.0, 1.1);
INSERT INTO species VALUES (17, "Pidgeot", 45, 0.5, 83, "Marrón", 80, 75, 70, 70, 101, 39.5, 1.5);
INSERT INTO species VALUES (18, "Rattata", 255, 0.5, 30, "Morado", 56, 35, 25, 35, 72, 3.5, 0.3);
INSERT INTO species VALUES (19, "Raticate", 127, 0.5, 55, "Marrón", 81, 60, 50, 70, 97, 18.5, 0.7);
INSERT INTO species VALUES (20, "Spearow", 255, 0.5, 40, "Marrón", 60, 30, 31, 31, 70, 2.0, 0.3);
INSERT INTO species VALUES (21, "Fearow", 90, 0.5, 65, "Marrón", 90, 65, 61, 61, 100, 38.0, 1.2);
INSERT INTO species VALUES (22, "Ekans", 255, 0.5, 35, "Morado", 60, 44, 40, 54, 55, 6.9, 2.0);
INSERT INTO species VALUES (23, "Arbok", 90, 0.5, 60, "Morado", 95, 69, 65, 79, 80, 65.0, 3.5);
INSERT INTO species VALUES (24, "Pikachu", 190, 0.5, 35, "Amarillo", 55, 40, 50, 50, 90, 6.0, 0.4);
INSERT INTO species VALUES (25, "Raichu", 75, 0.5, 60, "Amarillo", 90, 55, 90, 80, 110, 30.0, 0.8);
INSERT INTO species VALUES (26, "Sandshrew", 255, 0.5, 50, "Amarillo", 75, 85, 20, 30, 40, 12.0, 0.6);
INSERT INTO species VALUES (27, "Sandslash", 90, 0.5, 75, "Amarillo", 100, 110, 45, 55, 65, 29.5, 1.0);
INSERT INTO species VALUES (28, "Nidoran H", 235, 1, 55, "Azul", 47, 52, 40, 40, 41, 7.0, 0.4);
INSERT INTO species VALUES (29, "Nidorina", 120, 1, 70, "Azul", 62, 67, 55, 55, 56, 20.0, 0.8);
INSERT INTO species VALUES (30, "Nidoqueen", 45, 1, 90, "Azul", 92, 87, 75, 85, 76, 60.0, 1.3);
INSERT INTO species VALUES (31, "Nidoram M", 235, 0, 46, "Morado", 57, 40, 40, 40, 50, 9.0, 0.5);
INSERT INTO species VALUES (32, "Nidorino", 120, 0, 61, "Morado", 72, 57, 55, 55, 65, 19.5, 0.9);
INSERT INTO species VALUES (33, "Nidoking", 45, 0, 81, "Morado", 102, 77, 85, 75, 85, 62.0, 1.4);
INSERT INTO species VALUES (34, "Clefairy", 150, 0.75, 70, "Rosa", 45, 48, 60, 65, 35, 7.5, 0.6);
INSERT INTO species VALUES (35, "Clefable", 25, 0.75, 95, "Rosa", 70, 73, 95, 90, 60, 40.0, 1.3);
INSERT INTO species VALUES (36, "Vulpix", 190, 0.75, 38, "Marrón", 41, 40, 50, 65, 65, 9.9, 0.6);
INSERT INTO species VALUES (37, "Ninetales", 75, 0.75, 73, "Amarillo", 76, 75, 81, 100, 100, 19.9, 1.1);
INSERT INTO species VALUES (38, "Jiglypuff", 170, 0.75, 115, "Rosa", 45, 20, 45, 25, 20, 5.5, 0.5);
INSERT INTO species VALUES (39, "Wiglytuff", 50, 0.75, 140, "Rosa", 70, 45, 85, 50, 45, 12.0, 1.0);
INSERT INTO species VALUES (40, "Zubat", 255, 0.5, 40, "Morado", 45, 35, 30, 40, 55, 7.5, 0.8);
INSERT INTO species VALUES (41, "Golbat", 90, 0.5, 75, "Morado", 80, 70, 65, 75, 90, 55.0, 1.6);
INSERT INTO species VALUES (42, "Oddish", 255, 0.5, 45, "Azul", 50, 55, 75, 65, 30, 5.4, 0.5);
INSERT INTO species VALUES (43, "Gloom", 120, 0.5, 60, "Azul", 65, 70, 85, 75, 40, 8.6, 0.8);
INSERT INTO species VALUES (44, "Vileplume", 45, 0.5, 75, "Azul noche", 80, 85, 110, 90, 50, 18.6, 1.2);
INSERT INTO species VALUES (45, "Paras", 190, 0.5, 35, "Rojo", 70, 55, 45, 55, 25, 5.4, 0.3);
INSERT INTO species VALUES (46, "Parasect", 75, 0.5, 60, "Rojo", 95, 80, 60, 80, 30, 29.5, 1.0);
INSERT INTO species VALUES (47, "Venonat", 190, 0.5, 60, "Morado", 55, 50, 40, 55, 45, 30.0, 1.0);
INSERT INTO species VALUES (48, "Venomoth", 75, 0.5, 70, "Morado", 65, 60, 90, 75, 90, 12.5, 1.5);
INSERT INTO species VALUES (49, "Diglett", 255, 0.5, 10, "Marrón", 55, 25, 35, 45, 95, 0.8, 0.2);
INSERT INTO species VALUES (50, "Dugtrio", 50, 0.5, 35, "Marrón", 100, 50, 50, 70, 120, 33.3, 0.7);
INSERT INTO species VALUES (51, "Meowth", 255, 0.5, 40, "Amarillo", 45, 35, 40, 40, 90, 4.2, 0.4);
INSERT INTO species VALUES (52, "Persian", 90, 0.5, 65, "Amarillo", 70, 60, 65, 65, 115, 32.0, 1.0);
INSERT INTO species VALUES (53, "Psyduck", 190, 0.5, 50, "Amarillo", 52, 48, 65, 50, 55, 19.6, 0.8);
INSERT INTO species VALUES (54, "Golduck", 75, 0.5, 80, "Azul", 82, 78, 95, 80, 85, 76.6, 1.7);
INSERT INTO species VALUES (55, "Mankey", 190, 0.5, 40, "Marrón", 80, 35, 35, 45, 70, 28.0, 0.5);
INSERT INTO species VALUES (56, "Primeape", 75, 0.5, 65, "Marrón", 105, 60, 60, 70, 95, 32.0, 1.0);
INSERT INTO species VALUES (57, "Growlithe", 190, 0.25, 55, "Marrón", 70, 45, 70, 50, 60, 19.0, 0.7);
INSERT INTO species VALUES (58, "Arcanine", 75, 0.25, 90, "Naranja", 110, 80, 100, 80, 95, 155.0, 1.9);
INSERT INTO species VALUES (59, "Poliwag", 255, 0.5, 40, "Azul", 50, 40, 40, 40, 90, 12.4, 0.6);
INSERT INTO species VALUES (60, "Poliwhirl", 120, 0.5, 65, "Azul", 65, 65, 50, 50, 90, 20.0, 1.0);
INSERT INTO species VALUES (61, "Poliwrath", 45, 0.5, 90, "Azul", 95, 95, 70, 90, 70, 54.0, 1.3);
INSERT INTO species VALUES (62, "Abra", 200, 0.25, 25, "Marrón", 20, 15, 105, 55, 90, 19.5, 0.9);
INSERT INTO species VALUES (63, "Kadabra", 100, 0.25, 40, "Marrón", 35, 30, 120, 70, 105, 56.5, 1.3);
INSERT INTO species VALUES (64, "Alakazam", 50, 0.25, 55, "Marrón", 50, 45, 135, 95, 120, 48.0, 1.5);
INSERT INTO species VALUES (65, "Machop", 180, 0.25, 70, "Gris", 80, 50, 35, 35, 35, 19.5, 0.8);
INSERT INTO species VALUES (66, "Machoke", 90, 0.25, 80, "Gris", 100, 70, 50, 60, 45, 70.5, 1.5);
INSERT INTO species VALUES (67, "Machamp", 45, 0.25, 90, "Gris", 130, 80, 65, 85, 55, 130.0, 1.6);
INSERT INTO species VALUES (68, "Bellsprout", 255, 0.5, 50, "Verde", 75, 35, 70, 30, 40, 4.0, 0.7);
INSERT INTO species VALUES (69, "Weepinbell", 120, 0.5, 65, "Verde", 90, 50, 85, 45, 55, 6.4, 1.0);
INSERT INTO species VALUES (70, "Victreebel", 45, 0.5, 80, "Verde", 105, 65, 100, 70, 70, 15.5, 1.7);
INSERT INTO species VALUES (71, "Tentacool", 190, 0.5, 40, "Azul", 40, 35, 50, 100, 70, 45.5, 0.9);
INSERT INTO species VALUES (72, "Tentacruel", 60, 0.5, 80, "Azul", 70, 65, 80, 120, 100, 55.0, 1.6);
INSERT INTO species VALUES (73, "Geodude", 255, 0.5, 40, "Marrón", 80, 100, 30, 30, 20, 20.0, 0.4);
INSERT INTO species VALUES (74, "Graveler", 120, 0.5, 55, "Marrón", 95, 115, 45, 45, 35, 105.0, 1.0);
INSERT INTO species VALUES (75, "Golem", 45, 0.5, 80, "Marrón", 120, 130, 55, 65, 45, 300.0, 1.4);
INSERT INTO species VALUES (76, "Ponyta", 190, 0.5, 50, "Amarillo", 85, 55, 65, 65, 90, 30.0, 1.0);
INSERT INTO species VALUES (77, "Rapidash", 60, 0.5, 65, "Amarillo", 100, 70, 80, 80, 105, 95.0, 1.7);
INSERT INTO species VALUES (78, "Slowpoke", 190, 0.5, 90, "Rosa", 65, 65, 40, 40, 15, 36.0, 1.2);
INSERT INTO species VALUES (79, "Slowbro", 75, 0.5, 95, "Rosa", 75, 110, 100, 80, 30, 78.5, 1.6);
INSERT INTO species VALUES (80, "Magnemite", 190, 0.01, 25, "Gris", 35, 70, 95, 55, 45, 6.0, 0.3);
INSERT INTO species VALUES (81, "Magneton", 60, 0.01, 50, "Gris", 60, 95, 120, 70, 70, 60.0, 1.0);
INSERT INTO species VALUES (82, "Farfetch'd", 45, 0.5, 52, "Marrón", 90, 55, 58, 62, 60, 15.0, 0.8);
INSERT INTO species VALUES (83, "Doduo", 190, 0.5, 35, "Marrón", 85, 45, 35, 35, 75, 39.2, 1.4);
INSERT INTO species VALUES (84, "Dodrio", 45, 0.5, 60, "Marrón", 110, 70, 60, 60, 110, 85.2, 1.8);
INSERT INTO species VALUES (85, "Seel", 190, 0.5, 65, "Blanco", 45, 55, 45, 70, 45, 90.0, 1.1);
INSERT INTO species VALUES (86, "Dewgong", 75, 0.5, 90, "Blanco", 70, 80, 70, 95, 70, 120.0, 1.7);
INSERT INTO species VALUES (87, "Grimer", 190, 0.5, 80, "Morado", 80, 50, 40, 50, 25, 30.0, 0.9);
INSERT INTO species VALUES (88, "Muk", 75, 0.5, 105, "Morado", 105, 75, 65, 100, 50, 30.0, 1.2);
INSERT INTO species VALUES (89, "Shellder", 190, 0.5, 30, "Morado", 65, 100, 45, 25, 40, 4.0, 0.3);
INSERT INTO species VALUES (90, "Cloyster", 60, 0.5, 50, "Morado", 95, 180, 85, 45, 70, 132.5, 1.5);
INSERT INTO species VALUES (91, "Gastly", 190, 0.5, 30, "Morado", 35, 30, 100, 35, 80, 0.1, 1.3);
INSERT INTO species VALUES (92, "Haunter", 90, 0.5, 45, "Morado", 50, 45, 115, 55, 95, 0.1, 1.6);
INSERT INTO species VALUES (93, "Gengar", 45, 0.5, 60, "Morado", 65, 60, 130, 75, 110, 40.5, 1.5);
INSERT INTO species VALUES (94, "Onix", 45, 0.5, 35, "Gris", 45, 160, 30, 45, 70, 210.0, 8.8);
INSERT INTO species VALUES (95, "Drowzee", 190, 0.5, 60, "Amarillo", 48, 45, 43, 90, 42, 32.4, 1.0);
INSERT INTO species VALUES (96, "Hypno", 75, 0.5, 85, "Amarillo", 73, 70, 73, 115, 67, 75.6, 1.6);
INSERT INTO species VALUES (97, "Krabby", 225, 0.5, 30, "Rojo", 105, 90, 25, 25, 50, 6.5, 0.4);
INSERT INTO species VALUES (98, "Kingler", 60, 0.5, 55, "Rojo", 130, 115, 50, 50, 75, 60.0, 1.3);
INSERT INTO species VALUES (99, "Voltorb", 190, 0.01, 40, "Rojo", 30, 50, 55, 55, 100, 10.4, 0.5);
INSERT INTO species VALUES (100, "Electrode", 60, 0.01, 60, "Rojo", 50, 70, 80, 80, 150, 66.6, 1.2);
INSERT INTO species VALUES (101, "Exeggcute", 90, 0.5, 60, "Rosa", 40, 80, 60, 45, 40, 2.5, 0.4);
INSERT INTO species VALUES (102, "Exeggutor", 45, 0.5, 95, "Amarillo", 95, 85, 125, 75, 55, 120.0, 2.0);
INSERT INTO species VALUES (103, "Cubone", 190, 0.5, 50, "Marrón", 50, 95, 40, 50, 35, 6.5, 0.4);
INSERT INTO species VALUES (104, "Marowak", 75, 0.5, 60, "Marrón", 80, 110, 50, 80, 45, 45.0, 1.0);
INSERT INTO species VALUES (105, "Hitmonlee", 45, 0.0, 50, "Marrón", 120, 53, 35, 110, 87, 49.8, 1.5);
INSERT INTO species VALUES (106, "Hitmonchan", 45, 0.0, 50, "Marrón", 105, 79, 35, 110, 76, 50.2, 1.4);
INSERT INTO species VALUES (107, "Lickitung", 45, 0.5, 90, "Rosa", 55, 75, 60, 75, 30, 65.5, 1.2);
INSERT INTO species VALUES (108, "Koffing", 190, 0.5, 40, "Morado", 65, 95, 60, 45, 35, 1.0, 0.6);
INSERT INTO species VALUES (109, "Weezing", 60, 0.5, 65, "Morado", 90, 120, 85, 70, 60, 9.5, 1.2);
INSERT INTO species VALUES (110, "Rhyhorn", 120, 0.5, 80, "Gris", 85, 95, 30, 30, 25, 115.0, 1.0);
INSERT INTO species VALUES (111, "Rhydon", 60, 0.5, 105, "Gris", 130, 120, 45, 45, 40, 120.0, 1.9);
INSERT INTO species VALUES (112, "Chansey", 30, 1.0, 250, "Rosa", 5, 5, 35, 105, 50, 34.6, 1.1);
INSERT INTO species VALUES (113, "Tangela", 45, 0.5, 65, "Azul", 55, 115, 100, 40, 60, 35.0, 1.0);
INSERT INTO species VALUES (114, "Kangaskhan", 45, 1.0, 105, "Marrón", 95, 80, 40, 80, 90, 80.0, 2.2);
INSERT INTO species VALUES (115, "Horsea", 225, 0.5, 30, "Azul", 40, 70, 70, 25, 60, 8.0, 0.4);
INSERT INTO species VALUES (116, "Seadra", 75, 0.5, 55, "Azul", 65, 95, 95, 45, 85, 25.0, 1.2);
INSERT INTO species VALUES (117, "Goldeen", 225, 0.5, 45, "Rojo", 67, 60, 35, 50, 63, 15.0, 0.6);
INSERT INTO species VALUES (118, "Seaking", 60, 0.5, 80, "Rojo", 92, 65, 65, 80, 68, 39.0, 1.3);
INSERT INTO species VALUES (119, "Staryu", 225, 0.01, 30, "Marrón", 45, 55, 70, 55, 85, 34.5, 0.8);
INSERT INTO species VALUES (120, "Starmie", 60, 0.0, 60, "Morado", 75, 85, 100, 85, 115, 80.0, 1.1);
INSERT INTO species VALUES (121, "Mr. Mime", 45, 0.5, 40, "Rosa", 45, 65, 100, 120, 90, 54.5, 1.3);
INSERT INTO species VALUES (122, "Scyther", 45, 0.5, 70, "Verde", 110, 80, 55, 80, 105, 56.0, 1.5);
INSERT INTO species VALUES (123, "Jynx", 45, 1.0, 65, "Rojo", 50, 35, 115, 95, 95, 40.6, 1.4);
INSERT INTO species VALUES (124, "Electabuzz", 45, 0.25, 65, "Amarillo", 83, 57, 95, 85, 105, 30.0, 1.1);
INSERT INTO species VALUES (125, "Magmar", 45, 0.25, 65, "Rojo", 95, 57, 100, 85, 93, 44.5, 1.3);
INSERT INTO species VALUES (126, "Pinsir", 45, 0.5, 65, "Marrón", 125, 100, 55, 70, 85, 55.0, 1.5);
INSERT INTO species VALUES (127, "Tauros", 45, 0.0, 75, "Marrón", 100, 95, 40, 70, 110, 88.4, 1.4);
INSERT INTO species VALUES (128, "Magikarp", 255, 0.5, 20, "Rojo", 10, 55, 15, 20, 80, 10.0, 0.9);
INSERT INTO species VALUES (129, "Gyarados", 45, 0.5, 95, "Azul", 125, 79, 60, 100, 81, 235.0, 6.5);
INSERT INTO species VALUES (130, "Lapras", 45, 0.5, 130, "Azul", 85, 80, 85, 95, 60, 220.0, 2.5);
INSERT INTO species VALUES (131, "Ditto", 35, 0.01, 48, "Morado", 48, 48, 48, 48, 48, 4.0, 0.3);
INSERT INTO species VALUES (132, "Eevee", 45, 0.125, 55, "Marrón", 55, 50, 45, 65, 55, 6.5, 0.3);
INSERT INTO species VALUES (133, "Vaporeon", 45, 0.125, 130, "Azul", 65, 60, 110, 95, 65, 29.0, 1.0);
INSERT INTO species VALUES (134, "Jolteon", 45, 0.125, 65, "Amarillo", 65, 60, 110, 95, 130, 24.5, 0.8);
INSERT INTO species VALUES (135, "Flareon", 45, 0.125, 65, "Rojo", 130, 60, 95, 110, 65, 25.0, 0.9);
INSERT INTO species VALUES (136, "Porygon", 45, 0.01, 65, "Rosa", 60, 70, 85, 75, 40, 36.5, 0.8);
INSERT INTO species VALUES (137, "Omanyte", 45, 0.125, 35, "Azul", 40, 100, 90, 55, 35, 7.5, 0.4);
INSERT INTO species VALUES (138, "Omastar", 45, 0.125, 70, "Azul", 60, 125, 115, 70, 55, 35.0, 1.0);
INSERT INTO species VALUES (139, "Kabuto", 45, 0.125, 30, "Marrón", 80, 90, 55, 45, 55, 11.5, 0.5);
INSERT INTO species VALUES (140, "Kabutops", 45, 0.125, 60, "Marrón", 115, 105, 65, 70, 80, 40.5, 1.3);
INSERT INTO species VALUES (141, "Aerodactyl", 45, 0.125, 80, "Morado", 105, 65, 60, 75, 130, 59.0, 1.8);
INSERT INTO species VALUES (142, "Snorlax", 25, 0.125, 160, "Negro", 110, 65, 65, 110, 30, 460.0, 2.1);
INSERT INTO species VALUES (143, "Articuno", 3, 0.01, 90, "Azul", 85, 100, 95, 125, 85, 55.4, 1.7);
INSERT INTO species VALUES (144, "Zapdos", 3, 0.01, 90, "Amarillo", 90, 85, 125, 90, 100, 52.6, 1.6);
INSERT INTO species VALUES (145, "Moltres", 3, 0.01, 90, "Amarillo", 100, 90, 125, 85, 90, 60.0, 2.0);
INSERT INTO species VALUES (146, "Dratini", 45, 0.5, 41, "Azul", 64, 45, 50, 50, 50, 3.3, 1.8);
INSERT INTO species VALUES (147, "Dragonair", 45, 0.5, 61, "Azul", 84, 65, 70, 70, 70, 16.5, 4.0);
INSERT INTO species VALUES (148, "Dragonite", 45, 0.5, 91, "Marrón", 134, 95, 100, 100, 80, 210.0, 2.2);
INSERT INTO species VALUES (149, "Mewtwo", 3, 0.01, 106, "Morado", 110, 90, 154, 90, 130, 122.0, 2.0);
INSERT INTO species VALUES (150, "Mew", 45, 0.01, 100, "Rosa", 100, 100, 100, 100, 100, 4.0, 0.4);

SELECT * FROM species;
SELECT COUNT(*) FROM species;

DROP TABLE IF EXISTS colors;
CREATE TABLE colors
(
	num INT PRIMARY KEY,	# Número de orden
    numb INT				# Número
);

INSERT INTO colors VALUES(0, 0);
INSERT INTO colors VALUES(1, 8);
INSERT INTO colors VALUES(2, 7);
INSERT INTO colors VALUES(3, 15);
INSERT INTO colors VALUES(4, 4);
INSERT INTO colors VALUES(5, 12);
INSERT INTO colors VALUES(6, 5);
INSERT INTO colors VALUES(7, 13);
INSERT INTO colors VALUES(8, 1);
INSERT INTO colors VALUES(9, 9);
INSERT INTO colors VALUES(10, 3);
INSERT INTO colors VALUES(11, 11);
INSERT INTO colors VALUES(12, 2);
INSERT INTO colors VALUES(13, 10);
INSERT INTO colors VALUES(14, 6);
INSERT INTO colors VALUES(15, 14);
INSERT INTO colors VALUES(16, 12);

SELECT * FROM colors;

DROP TABLE IF EXISTS medicine;
CREATE TABLE medicine
(
	num INT PRIMARY KEY,	# Número de orden
    nam VARCHAR(25),		# Nombre
    minLife INT,
    maxLife INT,
    healingPower INT,
    energizingPower INT,
    price INT
);

INSERT INTO medicine VALUES(0, "Poción", 1, 999, 20, 0, 1000);
INSERT INTO medicine VALUES(1, "Súper poción", 1, 999, 60, 0, 2000);
INSERT INTO medicine VALUES(2, "Híper poción", 1, 999, 200, 0, 4000);
INSERT INTO medicine VALUES(3, "Máxima poción", 1, 999, 999, 0, 8000);
INSERT INTO medicine VALUES(4, "Revividora", 0, 0, 50, 0, 10000);
INSERT INTO medicine VALUES(5, "Revividora máxima", 0, 0, 100, 0, 20000);
INSERT INTO medicine VALUES(6, "Éter", 1, 999, 0, 100, 2000);
INSERT INTO medicine VALUES(7, "Máximo éter", 1, 999, 0, 100, 2000);
INSERT INTO medicine VALUES(8, "Elíxir", 1, 999, 0, 10, 4000);
INSERT INTO medicine VALUES(9, "Máximo elíxir", 1, 999, 0, 100, 8000);

SELECT * FROM medicine;

DROP TABLE IF EXISTS pokeballs;
CREATE TABLE pokeballs
(
	num INT PRIMARY KEY,	# Número de orden
    nam VARCHAR(25),		# Nombre
    captureRatio INT,		# Ratio de captura
    price INT				# Precio
);

INSERT INTO pokeballs VALUES(0, "Pokéball", 1, 100);
INSERT INTO pokeballs VALUES(1, "Súper ball", 50, 10000);
INSERT INTO pokeballs VALUES(2, "Ultra ball", 150, 100000);
INSERT INTO pokeballs VALUES(3, "Master ball", 255, 1000000);

SELECT * FROM pokeballs;

DROP TABLE IF EXISTS treasures;
CREATE TABLE treasures
(
	num INT PRIMARY KEY,	# Número de orden
    nam VARCHAR(25),		# Nombre
    price INT				# Precio
);

INSERT INTO treasures VALUES(0, "Perla", 1000);
INSERT INTO treasures VALUES(1, "Polvo de estrella", 1500);
INSERT INTO treasures VALUES(2, "Seta grande", 2500);
INSERT INTO treasures VALUES(3, "Perla grande", 4000);
INSERT INTO treasures VALUES(4, "Pepita", 5000);
INSERT INTO treasures VALUES(5, "Trozo de estrella", 6000);
INSERT INTO treasures VALUES(6, "Fragmento de cometa", 12500);
INSERT INTO treasures VALUES(7, "Pepita grande", 20000);
INSERT INTO treasures VALUES(8, "Oro real", 30000);

SELECT * FROM treasures;

DROP TABLE IF EXISTS moves;
CREATE TABLE moves
(
	num INT PRIMARY KEY,	# Número de orden
    nam VARCHAR(25),		# Nombre
    pp INT,					# Puntos de poder
    power INT,				# Potencia
    pre INT,				# Precisión
    priority INT			# Prioridad
);

INSERT INTO moves VALUES(0, "Ataque preciso", 10, 50, 100, 2);
INSERT INTO moves VALUES(1, "Ataque ligero", 10, 250, 50, 2);
INSERT INTO moves VALUES(2, "Ataque medio", 10, 500, 25, 2);
INSERT INTO moves VALUES(3, "Ataque pesado", 10, 1000, 10, 2);
INSERT INTO moves VALUES(4, "Ataque equilibrado", 10, 500, 50, 2);
INSERT INTO moves VALUES(5, "Ataque final", 25, 1000, 100, 2);
INSERT INTO moves VALUES(6, "Ataque rápido", 25, 50, 75, 1);

SELECT * FROM moves;

DROP TABLE IF EXISTS mts;
CREATE TABLE mts
(
	num INT PRIMARY KEY,	# Número de orden / Movimiento que enseña
    nam VARCHAR(25)			# Nombre
);

INSERT INTO mts VALUES(0, "Ataque preciso");
INSERT INTO mts VALUES(1, "Ataque ligero");
INSERT INTO mts VALUES(2, "Ataque medio");
INSERT INTO mts VALUES(3, "Ataque pesado");
INSERT INTO mts VALUES(4, "Ataque equilibrado");
INSERT INTO mts VALUES(5, "Ataque final");
INSERT INTO mts VALUES(6, "Ataque rápido");

SELECT * FROM mts;


