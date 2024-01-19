--
-- PostgreSQL database dump
--

-- Dumped from database version 15.3
-- Dumped by pg_dump version 15.3

-- Started on 2023-07-07 16:35:43

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_table_access_method = heap;

--
-- TOC entry 214 (class 1259 OID 16399)
-- Name: Brands; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."Brands" (
    "Id" uuid DEFAULT gen_random_uuid() NOT NULL,
    "Name" text NOT NULL,
    "Description" text NOT NULL,
    "IdImage" uuid NOT NULL,
    "FechaBaja" timestamp with time zone
);


--
-- TOC entry 215 (class 1259 OID 16404)
-- Name: Categories; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."Categories" (
    "Id" uuid DEFAULT gen_random_uuid() NOT NULL,
    "Name" text NOT NULL,
    "Icon" text,
    "IdImage" uuid,
    "IdFatherCategory" uuid,
    "FechaBaja" timestamp with time zone
);


--
-- TOC entry 216 (class 1259 OID 16409)
-- Name: Images; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."Images" (
    "Id" uuid DEFAULT gen_random_uuid() NOT NULL,
    "Path" text NOT NULL,
    "AlternativeText" text NOT NULL,
    "FechaBaja" timestamp with time zone
);


--
-- TOC entry 217 (class 1259 OID 16414)
-- Name: Products; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."Products" (
    "Id" uuid DEFAULT gen_random_uuid() NOT NULL,
    "Name" text NOT NULL,
    "Description" text NOT NULL,
    "IdCategory" uuid NOT NULL,
    "IdBrand" uuid NOT NULL,
    "FechaBaja" timestamp with time zone
);


--
-- TOC entry 218 (class 1259 OID 16419)
-- Name: ProductsImages; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."ProductsImages" (
    "Id" uuid DEFAULT gen_random_uuid() NOT NULL,
    "Priority" integer NOT NULL,
    "IdProduct" uuid NOT NULL,
    "IdImage" uuid NOT NULL,
    "FechaBaja" timestamp with time zone
);


--
-- TOC entry 219 (class 1259 OID 16422)
-- Name: Texts; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."Texts" (
    "Id" uuid DEFAULT gen_random_uuid() NOT NULL,
    "Code" text NOT NULL,
    "Value" text NOT NULL,
    "FechaBaja" timestamp with time zone
);


--
-- TOC entry 220 (class 1259 OID 16427)
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


--
-- TOC entry 3372 (class 0 OID 16399)
-- Dependencies: 214
-- Data for Name: Brands; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public."Brands" ("Id", "Name", "Description", "IdImage", "FechaBaja") FROM stdin;
c920fa40-8641-40ff-892b-6aa3eaff8af7	Nike	Marca deportiva líder en el mercado.	e1f825e0-49e4-4481-b2b9-42e5b51b36af	\N
7953ab72-1331-455e-83f6-b30b76d20a4b	Adidas	Marca reconocida mundialmente.	9f764a20-97fe-40ae-84f0-2887977f6c52	\N
6ac1a388-3c9a-41c1-b550-4ea479ab2788	Levis	Marca de jeans de alta calidad.	6c4c227d-5911-4b43-8d8a-6dbd97e0ab71	\N
\.


--
-- TOC entry 3373 (class 0 OID 16404)
-- Dependencies: 215
-- Data for Name: Categories; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public."Categories" ("Id", "Name", "Icon", "IdImage", "IdFatherCategory", "FechaBaja") FROM stdin;
dde59b27-d084-4c51-a862-b48898ec2dd3	Ropa	icon-pants.png	\N	\N	\N
1e27e0aa-b85d-47bb-b4c0-bf1a4f0e9754	Zapatillas	icon-shoes.png	\N	\N	\N
e5a98043-e792-4727-836a-610658f4bd62	Pantalones	icon-pants.png	\N	dde59b27-d084-4c51-a862-b48898ec2dd3	\N
3b62fb78-811a-4685-bac4-eff448fbd3c1	Camisetas	icon-shirts.png	\N	dde59b27-d084-4c51-a862-b48898ec2dd3	\N
aa4f5d15-8853-4bb7-9fbd-066de7aae559	Pantalones Cortos	\N	\N	e5a98043-e792-4727-836a-610658f4bd62	\N
\.


--
-- TOC entry 3374 (class 0 OID 16409)
-- Dependencies: 216
-- Data for Name: Images; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public."Images" ("Id", "Path", "AlternativeText", "FechaBaja") FROM stdin;
e1f825e0-49e4-4481-b2b9-42e5b51b36af	https://example.com/nikeLogo.jpg	Nike Logo	\N
9f764a20-97fe-40ae-84f0-2887977f6c52	https://example.com/adidasLogo.jpg	Adidas Logo	\N
6c4c227d-5911-4b43-8d8a-6dbd97e0ab71	https://example.com/levisLogo.jpg	Levis Logo	\N
42236d70-4bb8-4d60-b636-df3e9504b346	https://example.com/airForce1.jpg	Air Force 1	\N
ea3ae386-e5fe-47a0-b8a5-bed4c2f3d94c	https://example.com/JoggerAdidas.jpg	Jogger Adidas	\N
7ee532aa-bbd9-419f-89a9-52d8336e4c35	https://example.com/Vaqueros1.jpg	Vaqueros	\N
b071fb46-80a4-4fec-9701-644d9eef266d	https://example.com/JoggerAdidas2.jpg	Jogger Adidas 2	\N
fce08e4f-2957-40e3-9a46-e8dc95c43e95	https://example.com/camisetaNike1.jpg	Camiseta Nike	\N
05245c24-6e1c-4d62-97e8-0d377b5579e7	https://example.com/VaquerosCortos1.jpg	Vaqueros Cortos	\N
\.


--
-- TOC entry 3375 (class 0 OID 16414)
-- Dependencies: 217
-- Data for Name: Products; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public."Products" ("Id", "Name", "Description", "IdCategory", "IdBrand", "FechaBaja") FROM stdin;
d5d6ca59-1d21-47f0-8d7c-01d67a3e5383	Air Force 1	Zapatilla mitica	1e27e0aa-b85d-47bb-b4c0-bf1a4f0e9754	c920fa40-8641-40ff-892b-6aa3eaff8af7	\N
efccf0a0-8c46-47b3-a1fd-5ba88912bc36	Vaqueros	Vaquero alta calidad	e5a98043-e792-4727-836a-610658f4bd62	6ac1a388-3c9a-41c1-b550-4ea479ab2788	\N
b2a11131-7a25-412c-b942-e77f181aeb24	Vaqueros Cortos	Vaquero corto alta calidad	aa4f5d15-8853-4bb7-9fbd-066de7aae559	6ac1a388-3c9a-41c1-b550-4ea479ab2788	\N
69a22408-1ae3-4ede-a143-19f5a0456e06	Joggers	Joggers muy comodos	e5a98043-e792-4727-836a-610658f4bd62	7953ab72-1331-455e-83f6-b30b76d20a4b	\N
1b4e4765-b1ed-40e6-8d91-46f4afddec2c	Camiseta	Camiseta de correr	3b62fb78-811a-4685-bac4-eff448fbd3c1	c920fa40-8641-40ff-892b-6aa3eaff8af7	\N
\.


--
-- TOC entry 3376 (class 0 OID 16419)
-- Dependencies: 218
-- Data for Name: ProductsImages; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public."ProductsImages" ("Id", "Priority", "IdProduct", "IdImage", "FechaBaja") FROM stdin;
8bcd0fb0-668d-4467-906b-53182da4d682	1	d5d6ca59-1d21-47f0-8d7c-01d67a3e5383	42236d70-4bb8-4d60-b636-df3e9504b346	\N
a01ab34e-74c9-4c9a-b720-a576516943eb	1	69a22408-1ae3-4ede-a143-19f5a0456e06	ea3ae386-e5fe-47a0-b8a5-bed4c2f3d94c	\N
ab5f0efd-fb2b-491c-9e17-b7a3563432bf	1	efccf0a0-8c46-47b3-a1fd-5ba88912bc36	7ee532aa-bbd9-419f-89a9-52d8336e4c35	\N
88136a09-b9a7-4d71-bf37-b9284c3bac2e	2	69a22408-1ae3-4ede-a143-19f5a0456e06	b071fb46-80a4-4fec-9701-644d9eef266d	\N
3fea29bf-e756-4a5d-a3c8-fefd51753ff7	1	1b4e4765-b1ed-40e6-8d91-46f4afddec2c	fce08e4f-2957-40e3-9a46-e8dc95c43e95	\N
2caed4b9-ab93-4709-a723-5ded586aff28	1	b2a11131-7a25-412c-b942-e77f181aeb24	05245c24-6e1c-4d62-97e8-0d377b5579e7	\N
\.


--
-- TOC entry 3377 (class 0 OID 16422)
-- Dependencies: 219
-- Data for Name: Texts; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public."Texts" ("Id", "Code", "Value", "FechaBaja") FROM stdin;
\.


--
-- TOC entry 3378 (class 0 OID 16427)
-- Dependencies: 220
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
\.


--
-- TOC entry 3204 (class 2606 OID 16431)
-- Name: Brands PK_Brands; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Brands"
    ADD CONSTRAINT "PK_Brands" PRIMARY KEY ("Id");


--
-- TOC entry 3208 (class 2606 OID 16433)
-- Name: Categories PK_Categories; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Categories"
    ADD CONSTRAINT "PK_Categories" PRIMARY KEY ("Id");


--
-- TOC entry 3210 (class 2606 OID 16435)
-- Name: Images PK_Images; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Images"
    ADD CONSTRAINT "PK_Images" PRIMARY KEY ("Id");


--
-- TOC entry 3214 (class 2606 OID 16437)
-- Name: Products PK_Products; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Products"
    ADD CONSTRAINT "PK_Products" PRIMARY KEY ("Id");


--
-- TOC entry 3218 (class 2606 OID 16439)
-- Name: ProductsImages PK_ProductsImages; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."ProductsImages"
    ADD CONSTRAINT "PK_ProductsImages" PRIMARY KEY ("Id");


--
-- TOC entry 3220 (class 2606 OID 16441)
-- Name: Texts PK_Texts; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Texts"
    ADD CONSTRAINT "PK_Texts" PRIMARY KEY ("Id");


--
-- TOC entry 3222 (class 2606 OID 16443)
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- TOC entry 3205 (class 1259 OID 16445)
-- Name: IX_Categories_IdFatherCategory; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_Categories_IdFatherCategory" ON public."Categories" USING btree ("IdFatherCategory");


--
-- TOC entry 3206 (class 1259 OID 16446)
-- Name: IX_Categories_IdImage; Type: INDEX; Schema: public; Owner: -
--

CREATE UNIQUE INDEX "IX_Categories_IdImage" ON public."Categories" USING btree ("IdImage");


--
-- TOC entry 3215 (class 1259 OID 16447)
-- Name: IX_ProductsImages_IdImage; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_ProductsImages_IdImage" ON public."ProductsImages" USING btree ("IdImage");


--
-- TOC entry 3216 (class 1259 OID 16448)
-- Name: IX_ProductsImages_IdProduct; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_ProductsImages_IdProduct" ON public."ProductsImages" USING btree ("IdProduct");


--
-- TOC entry 3211 (class 1259 OID 16449)
-- Name: IX_Products_IdBrand; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_Products_IdBrand" ON public."Products" USING btree ("IdBrand");


--
-- TOC entry 3212 (class 1259 OID 16450)
-- Name: IX_Products_IdCategory; Type: INDEX; Schema: public; Owner: -
--

CREATE INDEX "IX_Products_IdCategory" ON public."Products" USING btree ("IdCategory");


--
-- TOC entry 3223 (class 2606 OID 16451)
-- Name: Brands FK_Brands_Images_IdImage; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Brands"
    ADD CONSTRAINT "FK_Brands_Images_IdImage" FOREIGN KEY ("IdImage") REFERENCES public."Images"("Id") ON DELETE CASCADE;


--
-- TOC entry 3224 (class 2606 OID 16456)
-- Name: Categories FK_Categories_Categories_IdFatherCategory; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Categories"
    ADD CONSTRAINT "FK_Categories_Categories_IdFatherCategory" FOREIGN KEY ("IdFatherCategory") REFERENCES public."Categories"("Id");


--
-- TOC entry 3225 (class 2606 OID 16461)
-- Name: Categories FK_Categories_Images_IdImage; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Categories"
    ADD CONSTRAINT "FK_Categories_Images_IdImage" FOREIGN KEY ("IdImage") REFERENCES public."Images"("Id") ON DELETE CASCADE;


--
-- TOC entry 3228 (class 2606 OID 16466)
-- Name: ProductsImages FK_ProductsImages_Images_IdImage; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."ProductsImages"
    ADD CONSTRAINT "FK_ProductsImages_Images_IdImage" FOREIGN KEY ("IdImage") REFERENCES public."Images"("Id") ON DELETE CASCADE;


--
-- TOC entry 3229 (class 2606 OID 16471)
-- Name: ProductsImages FK_ProductsImages_Products_IdProduct; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."ProductsImages"
    ADD CONSTRAINT "FK_ProductsImages_Products_IdProduct" FOREIGN KEY ("IdProduct") REFERENCES public."Products"("Id") ON DELETE CASCADE;


--
-- TOC entry 3226 (class 2606 OID 16476)
-- Name: Products FK_Products_Brands_IdBrand; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Products"
    ADD CONSTRAINT "FK_Products_Brands_IdBrand" FOREIGN KEY ("IdBrand") REFERENCES public."Brands"("Id") ON DELETE CASCADE;


--
-- TOC entry 3227 (class 2606 OID 16481)
-- Name: Products FK_Products_Categories_IdCategory; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Products"
    ADD CONSTRAINT "FK_Products_Categories_IdCategory" FOREIGN KEY ("IdCategory") REFERENCES public."Categories"("Id") ON DELETE CASCADE;


-- Completed on 2023-07-07 16:35:43

--
-- PostgreSQL database dump complete
--

