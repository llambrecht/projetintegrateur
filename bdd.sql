DROP TABLE IF EXISTS Possede;
DROP TABLE IF EXISTS Equipe;
DROP TABLE IF EXISTS Est_Compose_De;
DROP TABLE IF EXISTS Est_Dans;
DROP TABLE IF EXISTS Materiau;
DROP TABLE IF EXISTS Inventaire;
DROP TABLE IF EXISTS Vaisseau;
DROP TABLE IF EXISTS Arme;
DROP TABLE IF EXISTS Joueur;
DROP TABLE IF EXISTS Rarete;
DROP TABLE IF EXISTS Amelioration;


CREATE TABLE IF NOT EXISTS Joueur (
  joueur_id INT NOT NULL AUTO_INCREMENT,
  joueur_nom VARCHAR(50) NOT NULL,
  joueur_mdp VARCHAR(40) NOT NULL,
  joueur_niveau INT DEFAULT 1,
  joueur_xp INT DEFAULT 0,
  PRIMARY KEY (joueur_id)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS Inventaire (
  inventaire_id INT NOT NULL AUTO_INCREMENT,
  inventaire_joueur_id INT NOT NULL,
  inventaire_slot_max INT DEFAULT 10,
  PRIMARY KEY (inventaire_id),
  CONSTRAINT Inventaire_fk_1 FOREIGN KEY (inventaire_joueur_id) REFERENCES Joueur(joueur_id)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS Rarete (
  rarete_id INT NOT NULL AUTO_INCREMENT,
  rarete_libelle VARCHAR(50),
  PRIMARY KEY (rarete_id)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS Materiau (
  materiau_id INT NOT NULL AUTO_INCREMENT,
  materiau_image VARCHAR(255),
  materiau_description VARCHAR(1024),
  materiau_rarete_id INT NOT NULL,
  PRIMARY KEY (materiau_id),
  CONSTRAINT Materiau_fk_1 FOREIGN KEY (materiau_rarete_id) REFERENCES Rarete(rarete_id)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS Est_Dans (
  ed_inventaire_id INT NOT NULL,
  ed_materiau_id INT NOT NULL,
  ed_quantite INT DEFAULT 1,
  PRIMARY KEY (ed_inventaire_id, ed_materiau_id),
  CONSTRAINT ED_fk_1 FOREIGN KEY (ed_inventaire_id) REFERENCES Inventaire(inventaire_id),
  CONSTRAINT ED_fk_2 FOREIGN KEY (ed_materiau_id) REFERENCES Materiau(materiau_id)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS Amelioration (
  amelioration_id INT NOT NULL AUTO_INCREMENT,
  amelioration_nom VARCHAR(50) NOT NULL,
  amelioration_pv INT DEFAULT 0,
  amelioration_vitesse INT DEFAULT 0,
  amerlioration_degat INT DEFAULT 0,
  PRIMARY KEY (amelioration_id)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS Est_Compose_De (
  ecd_materiau_id INT NOT NULL,
  ecd_amelioration_id INT NOT NULL,
  ecd_quantite INT DEFAULT 1,
  PRIMARY KEY (ecd_materiau_id, ecd_amelioration_id),
  CONSTRAINT ECD_fk_1 FOREIGN KEY (ecd_materiau_id) REFERENCES Materiau(materiau_id),
  CONSTRAINT ECD_fk_2 FOREIGN KEY (ecd_amelioration_id) REFERENCES Amelioration(amelioration_id)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS Vaisseau (
  vaisseau_id INT NOT NULL AUTO_INCREMENT,
  vaisseau_nom VARCHAR(50),
  vaisseau_type VARCHAR(50),
  vaisseau_pv INT,
  vaisseau_degat INT,
  vaisseau_vitesse INT,
  vaisseau_image VARCHAR(100),
  PRIMARY KEY (vaisseau_id)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS Possede (
  possede_joueur_id INT NOT NULL,
  possede_amelioration_id INT NOT NULL,
  possede_vaisseau_id INT NOT NULL,
  PRIMARY KEY (possede_joueur_id, possede_amelioration_id, possede_vaisseau_id),
  CONSTRAINT possede_fk_1 FOREIGN KEY (possede_joueur_id) REFERENCES Joueur(joueur_id),
  CONSTRAINT possede_fk_2 FOREIGN KEY (possede_amelioration_id) REFERENCES Amelioration(amelioration_id),
  CONSTRAINT possede_fk_3 FOREIGN KEY (possede_vaisseau_id) REFERENCES Vaisseau(vaisseau_id)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS Arme (
  arme_id INT NOT NULL AUTO_INCREMENT,
  arme_nom VARCHAR(50),
  arme_type VARCHAR(50),
  arme_degat INT DEFAULT 1,
  arme_temps_recharge INT,
  arme_image VARCHAR(100),
  PRIMARY KEY (arme_id)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS Equipe (
  equipe_vaisseau_id INT NOT NULL,
  equipe_arme_id INT NOT NULL,
  PRIMARY KEY (equipe_vaisseau_id, equipe_arme_id),
  CONSTRAINT equipe_fk_1 FOREIGN KEY (equipe_vaisseau_id) REFERENCES Vaisseau(vaisseau_id),
  CONSTRAINT equipe_fk_2 FOREIGN KEY (equipe_arme_id) REFERENCES Arme(arme_id)
) ENGINE = InnoDB DEFAULT CHARSET = utf8;

-- CREATE TABLE IF NOT EXISTS Boost (
--   boost_id INT NOT NULL AUTO_INCREMENT,
--   boost_pv INT,
--   boost_degat INT,
--   boost_vitesse INT,
--   boost_duree INT,
--   PRIMARY KEY (boost_id)
-- ) ENGINE = InnoDB DEFAULT CHARSET = utf8;
