--
-- PostgreSQL database dump
--

-- Dumped from database version 16.2
-- Dumped by pg_dump version 16.2

-- Started on 2024-04-20 15:06:33

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

--
-- TOC entry 220 (class 1255 OID 24582)
-- Name: all_courses(); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.all_courses()
    LANGUAGE sql
    AS $$
    SELECT course_name FROM courseset;
$$;


ALTER PROCEDURE public.all_courses() OWNER TO postgres;

--
-- TOC entry 221 (class 1255 OID 24583)
-- Name: all_courses(integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.all_courses(IN num integer)
    LANGUAGE sql
    AS $$
    SELECT * FROM courseset
	Where "id" =num;
$$;


ALTER PROCEDURE public.all_courses(IN num integer) OWNER TO postgres;

--
-- TOC entry 218 (class 1255 OID 24580)
-- Name: delete_course(integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.delete_course(IN in_id integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    DELETE FROM courseset WHERE "id" = in_id;
END;
$$;


ALTER PROCEDURE public.delete_course(IN in_id integer) OWNER TO postgres;

--
-- TOC entry 217 (class 1255 OID 24576)
-- Name: insert_course(integer, character varying); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.insert_course(IN in_id integer, IN in_name character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO CourseSet ("id", course_name)
    VALUES (in_id, in_name);
    
    
END;
$$;


ALTER PROCEDURE public.insert_course(IN in_id integer, IN in_name character varying) OWNER TO postgres;

--
-- TOC entry 219 (class 1255 OID 24581)
-- Name: update_course(integer, text); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.update_course(IN course_id integer, IN new_name text)
    LANGUAGE sql
    AS $$
    UPDATE courseset
    SET course_name = new_name
    WHERE "id" = course_id;
$$;


ALTER PROCEDURE public.update_course(IN course_id integer, IN new_name text) OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 215 (class 1259 OID 16520)
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 16526)
-- Name: courseset; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.courseset (
    id integer NOT NULL,
    course_name text
);


ALTER TABLE public.courseset OWNER TO postgres;

--
-- TOC entry 4643 (class 2606 OID 16524)
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- TOC entry 4645 (class 2606 OID 24579)
-- Name: courseset PK_courseset; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.courseset
    ADD CONSTRAINT "PK_courseset" PRIMARY KEY (id);


-- Completed on 2024-04-20 15:06:33

--
-- PostgreSQL database dump complete
--

