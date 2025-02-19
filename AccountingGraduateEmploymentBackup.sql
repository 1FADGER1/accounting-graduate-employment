PGDMP      ,                |            AccountingGraduateEmployment    16.3    16.3 W               0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    16397    AccountingGraduateEmployment    DATABASE     �   CREATE DATABASE "AccountingGraduateEmployment" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
 .   DROP DATABASE "AccountingGraduateEmployment";
                postgres    false            Z           1247    16484    form_education    TYPE     u   CREATE TYPE public.form_education AS ENUM (
    'очная',
    'очно-заочная',
    'заочная'
);
 !   DROP TYPE public.form_education;
       public          postgres    false            ]           1247    16492    gender    TYPE     R   CREATE TYPE public.gender AS ENUM (
    'мужской',
    'женский'
);
    DROP TYPE public.gender;
       public          postgres    false            `           1247    16511    typeemployment    TYPE     �   CREATE TYPE public.typeemployment AS ENUM (
    'работает',
    'самозанятый',
    'безработный',
    'проходить_службу_в_вс'
);
 !   DROP TYPE public.typeemployment;
       public          postgres    false            �            1259    16699    Address    TABLE     8  CREATE TABLE public."Address" (
    "ID" integer NOT NULL,
    country text NOT NULL,
    region text NOT NULL,
    district text NOT NULL,
    locality text NOT NULL,
    city text NOT NULL,
    street text NOT NULL,
    house_number character varying(10) NOT NULL,
    apartment_number character varying(8)
);
    DROP TABLE public."Address";
       public         heap    postgres    false            �            1259    16698    Address_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."Address_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public."Address_ID_seq";
       public          postgres    false    231                       0    0    Address_ID_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public."Address_ID_seq" OWNED BY public."Address"."ID";
          public          postgres    false    230            �            1259    16583    GraduateStudent    TABLE     �  CREATE TABLE public."GraduateStudent" (
    "ID" integer NOT NULL,
    full_name text NOT NULL,
    birth_date date NOT NULL,
    gender public.gender NOT NULL,
    nationality text,
    "ID_residential_address" integer NOT NULL,
    phone_number character varying(21),
    "Email" text,
    "SNILS" character varying(11) NOT NULL,
    code_specialty integer NOT NULL,
    year_admission date NOT NULL,
    year_graduation date NOT NULL,
    form_education public.form_education NOT NULL
);
 %   DROP TABLE public."GraduateStudent";
       public         heap    postgres    false    861    858            �            1259    16580    GraduateStudent_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."GraduateStudent_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 /   DROP SEQUENCE public."GraduateStudent_ID_seq";
       public          postgres    false    222                       0    0    GraduateStudent_ID_seq    SEQUENCE OWNED BY     W   ALTER SEQUENCE public."GraduateStudent_ID_seq" OWNED BY public."GraduateStudent"."ID";
          public          postgres    false    219            �            1259    16574    EmploymentStatus    TABLE     �   CREATE TABLE public."EmploymentStatus" (
    "ID" integer DEFAULT nextval('public."GraduateStudent_ID_seq"'::regclass) NOT NULL,
    "ID_student" integer NOT NULL,
    start_date date,
    type_employment public.typeemployment NOT NULL
);
 &   DROP TABLE public."EmploymentStatus";
       public         heap    postgres    false    219    864            �            1259    16573    EmploymentStatus_ID_student_seq    SEQUENCE     �   CREATE SEQUENCE public."EmploymentStatus_ID_student_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 8   DROP SEQUENCE public."EmploymentStatus_ID_student_seq";
       public          postgres    false    218                       0    0    EmploymentStatus_ID_student_seq    SEQUENCE OWNED BY     i   ALTER SEQUENCE public."EmploymentStatus_ID_student_seq" OWNED BY public."EmploymentStatus"."ID_student";
          public          postgres    false    217            �            1259    16581 *   GraduateStudent_ID_residential_address_seq    SEQUENCE     �   CREATE SEQUENCE public."GraduateStudent_ID_residential_address_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 C   DROP SEQUENCE public."GraduateStudent_ID_residential_address_seq";
       public          postgres    false    222                       0    0 *   GraduateStudent_ID_residential_address_seq    SEQUENCE OWNED BY        ALTER SEQUENCE public."GraduateStudent_ID_residential_address_seq" OWNED BY public."GraduateStudent"."ID_residential_address";
          public          postgres    false    220            �            1259    16582 "   GraduateStudent_code_specialty_seq    SEQUENCE     �   CREATE SEQUENCE public."GraduateStudent_code_specialty_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ;   DROP SEQUENCE public."GraduateStudent_code_specialty_seq";
       public          postgres    false    222                       0    0 "   GraduateStudent_code_specialty_seq    SEQUENCE OWNED BY     m   ALTER SEQUENCE public."GraduateStudent_code_specialty_seq" OWNED BY public."GraduateStudent".code_specialty;
          public          postgres    false    221            �            1259    16595    Jobs    TABLE     �   CREATE TABLE public."Jobs" (
    "ID" integer NOT NULL,
    "ID_status" integer NOT NULL,
    "ID_workplace" integer NOT NULL,
    "position" text NOT NULL,
    availability_employment boolean
);
    DROP TABLE public."Jobs";
       public         heap    postgres    false            �            1259    16593    Jobs_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."Jobs_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 $   DROP SEQUENCE public."Jobs_ID_seq";
       public          postgres    false    225                       0    0    Jobs_ID_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE public."Jobs_ID_seq" OWNED BY public."Jobs"."ID";
          public          postgres    false    223            �            1259    16594    Jobs_ID_workplace_seq    SEQUENCE     �   CREATE SEQUENCE public."Jobs_ID_workplace_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public."Jobs_ID_workplace_seq";
       public          postgres    false    225                       0    0    Jobs_ID_workplace_seq    SEQUENCE OWNED BY     U   ALTER SEQUENCE public."Jobs_ID_workplace_seq" OWNED BY public."Jobs"."ID_workplace";
          public          postgres    false    224            �            1259    16605    MilitaryService    TABLE     �   CREATE TABLE public."MilitaryService" (
    "ID" integer NOT NULL,
    "ID_status" integer NOT NULL,
    place_service text NOT NULL,
    post_military text NOT NULL
);
 %   DROP TABLE public."MilitaryService";
       public         heap    postgres    false            �            1259    16604    MilitaryService_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."MilitaryService_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 /   DROP SEQUENCE public."MilitaryService_ID_seq";
       public          postgres    false    227                        0    0    MilitaryService_ID_seq    SEQUENCE OWNED BY     W   ALTER SEQUENCE public."MilitaryService_ID_seq" OWNED BY public."MilitaryService"."ID";
          public          postgres    false    226            �            1259    16749    SelfEmployment    TABLE     �   CREATE TABLE public."SelfEmployment" (
    "ID" integer NOT NULL,
    "ID_status" integer NOT NULL,
    type_activity text NOT NULL
);
 $   DROP TABLE public."SelfEmployment";
       public         heap    postgres    false            �            1259    16748    SelfEmployment_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."SelfEmployment_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public."SelfEmployment_ID_seq";
       public          postgres    false    233            !           0    0    SelfEmployment_ID_seq    SEQUENCE OWNED BY     U   ALTER SEQUENCE public."SelfEmployment_ID_seq" OWNED BY public."SelfEmployment"."ID";
          public          postgres    false    232            �            1259    16685 	   Specialty    TABLE     �   CREATE TABLE public."Specialty" (
    code_specialty integer NOT NULL,
    name_specialty text NOT NULL,
    training_profile text NOT NULL
);
    DROP TABLE public."Specialty";
       public         heap    postgres    false            �            1259    16684    Specialty_code_specialty_seq    SEQUENCE     �   CREATE SEQUENCE public."Specialty_code_specialty_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 5   DROP SEQUENCE public."Specialty_code_specialty_seq";
       public          postgres    false    229            "           0    0    Specialty_code_specialty_seq    SEQUENCE OWNED BY     a   ALTER SEQUENCE public."Specialty_code_specialty_seq" OWNED BY public."Specialty".code_specialty;
          public          postgres    false    228            �            1259    16565 	   Workplace    TABLE     �   CREATE TABLE public."Workplace" (
    "ID" integer NOT NULL,
    "Appellation" text NOT NULL,
    "OKVED" character varying(21) NOT NULL,
    "INN" character varying(18) NOT NULL,
    "Region" text NOT NULL
);
    DROP TABLE public."Workplace";
       public         heap    postgres    false            �            1259    16564    Workplace_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."Workplace_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public."Workplace_ID_seq";
       public          postgres    false    216            #           0    0    Workplace_ID_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE public."Workplace_ID_seq" OWNED BY public."Workplace"."ID";
          public          postgres    false    215            S           2604    16702 
   Address ID    DEFAULT     n   ALTER TABLE ONLY public."Address" ALTER COLUMN "ID" SET DEFAULT nextval('public."Address_ID_seq"'::regclass);
 =   ALTER TABLE public."Address" ALTER COLUMN "ID" DROP DEFAULT;
       public          postgres    false    230    231    231            K           2604    16577    EmploymentStatus ID_student    DEFAULT     �   ALTER TABLE ONLY public."EmploymentStatus" ALTER COLUMN "ID_student" SET DEFAULT nextval('public."EmploymentStatus_ID_student_seq"'::regclass);
 N   ALTER TABLE public."EmploymentStatus" ALTER COLUMN "ID_student" DROP DEFAULT;
       public          postgres    false    217    218    218            L           2604    16586    GraduateStudent ID    DEFAULT     ~   ALTER TABLE ONLY public."GraduateStudent" ALTER COLUMN "ID" SET DEFAULT nextval('public."GraduateStudent_ID_seq"'::regclass);
 E   ALTER TABLE public."GraduateStudent" ALTER COLUMN "ID" DROP DEFAULT;
       public          postgres    false    222    219    222            M           2604    16587 &   GraduateStudent ID_residential_address    DEFAULT     �   ALTER TABLE ONLY public."GraduateStudent" ALTER COLUMN "ID_residential_address" SET DEFAULT nextval('public."GraduateStudent_ID_residential_address_seq"'::regclass);
 Y   ALTER TABLE public."GraduateStudent" ALTER COLUMN "ID_residential_address" DROP DEFAULT;
       public          postgres    false    222    220    222            N           2604    16588    GraduateStudent code_specialty    DEFAULT     �   ALTER TABLE ONLY public."GraduateStudent" ALTER COLUMN code_specialty SET DEFAULT nextval('public."GraduateStudent_code_specialty_seq"'::regclass);
 O   ALTER TABLE public."GraduateStudent" ALTER COLUMN code_specialty DROP DEFAULT;
       public          postgres    false    221    222    222            O           2604    16598    Jobs ID    DEFAULT     h   ALTER TABLE ONLY public."Jobs" ALTER COLUMN "ID" SET DEFAULT nextval('public."Jobs_ID_seq"'::regclass);
 :   ALTER TABLE public."Jobs" ALTER COLUMN "ID" DROP DEFAULT;
       public          postgres    false    225    223    225            P           2604    16599    Jobs ID_workplace    DEFAULT     |   ALTER TABLE ONLY public."Jobs" ALTER COLUMN "ID_workplace" SET DEFAULT nextval('public."Jobs_ID_workplace_seq"'::regclass);
 D   ALTER TABLE public."Jobs" ALTER COLUMN "ID_workplace" DROP DEFAULT;
       public          postgres    false    224    225    225            Q           2604    16608    MilitaryService ID    DEFAULT     ~   ALTER TABLE ONLY public."MilitaryService" ALTER COLUMN "ID" SET DEFAULT nextval('public."MilitaryService_ID_seq"'::regclass);
 E   ALTER TABLE public."MilitaryService" ALTER COLUMN "ID" DROP DEFAULT;
       public          postgres    false    226    227    227            T           2604    16752    SelfEmployment ID    DEFAULT     |   ALTER TABLE ONLY public."SelfEmployment" ALTER COLUMN "ID" SET DEFAULT nextval('public."SelfEmployment_ID_seq"'::regclass);
 D   ALTER TABLE public."SelfEmployment" ALTER COLUMN "ID" DROP DEFAULT;
       public          postgres    false    232    233    233            R           2604    16688    Specialty code_specialty    DEFAULT     �   ALTER TABLE ONLY public."Specialty" ALTER COLUMN code_specialty SET DEFAULT nextval('public."Specialty_code_specialty_seq"'::regclass);
 I   ALTER TABLE public."Specialty" ALTER COLUMN code_specialty DROP DEFAULT;
       public          postgres    false    228    229    229            I           2604    16568    Workplace ID    DEFAULT     r   ALTER TABLE ONLY public."Workplace" ALTER COLUMN "ID" SET DEFAULT nextval('public."Workplace_ID_seq"'::regclass);
 ?   ALTER TABLE public."Workplace" ALTER COLUMN "ID" DROP DEFAULT;
       public          postgres    false    216    215    216                      0    16699    Address 
   TABLE DATA           |   COPY public."Address" ("ID", country, region, district, locality, city, street, house_number, apartment_number) FROM stdin;
    public          postgres    false    231   �j                 0    16574    EmploymentStatus 
   TABLE DATA           ]   COPY public."EmploymentStatus" ("ID", "ID_student", start_date, type_employment) FROM stdin;
    public          postgres    false    218   Ak                 0    16583    GraduateStudent 
   TABLE DATA           �   COPY public."GraduateStudent" ("ID", full_name, birth_date, gender, nationality, "ID_residential_address", phone_number, "Email", "SNILS", code_specialty, year_admission, year_graduation, form_education) FROM stdin;
    public          postgres    false    222   �k       
          0    16595    Jobs 
   TABLE DATA           h   COPY public."Jobs" ("ID", "ID_status", "ID_workplace", "position", availability_employment) FROM stdin;
    public          postgres    false    225   l                 0    16605    MilitaryService 
   TABLE DATA           \   COPY public."MilitaryService" ("ID", "ID_status", place_service, post_military) FROM stdin;
    public          postgres    false    227   Wl                 0    16749    SelfEmployment 
   TABLE DATA           L   COPY public."SelfEmployment" ("ID", "ID_status", type_activity) FROM stdin;
    public          postgres    false    233   tl                 0    16685 	   Specialty 
   TABLE DATA           W   COPY public."Specialty" (code_specialty, name_specialty, training_profile) FROM stdin;
    public          postgres    false    229   �l                 0    16565 	   Workplace 
   TABLE DATA           T   COPY public."Workplace" ("ID", "Appellation", "OKVED", "INN", "Region") FROM stdin;
    public          postgres    false    216   jm       $           0    0    Address_ID_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public."Address_ID_seq"', 17, true);
          public          postgres    false    230            %           0    0    EmploymentStatus_ID_student_seq    SEQUENCE SET     P   SELECT pg_catalog.setval('public."EmploymentStatus_ID_student_seq"', 1, false);
          public          postgres    false    217            &           0    0 *   GraduateStudent_ID_residential_address_seq    SEQUENCE SET     [   SELECT pg_catalog.setval('public."GraduateStudent_ID_residential_address_seq"', 1, false);
          public          postgres    false    220            '           0    0    GraduateStudent_ID_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('public."GraduateStudent_ID_seq"', 29, true);
          public          postgres    false    219            (           0    0 "   GraduateStudent_code_specialty_seq    SEQUENCE SET     S   SELECT pg_catalog.setval('public."GraduateStudent_code_specialty_seq"', 1, false);
          public          postgres    false    221            )           0    0    Jobs_ID_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('public."Jobs_ID_seq"', 3, true);
          public          postgres    false    223            *           0    0    Jobs_ID_workplace_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public."Jobs_ID_workplace_seq"', 1, false);
          public          postgres    false    224            +           0    0    MilitaryService_ID_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public."MilitaryService_ID_seq"', 1, true);
          public          postgres    false    226            ,           0    0    SelfEmployment_ID_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public."SelfEmployment_ID_seq"', 4, true);
          public          postgres    false    232            -           0    0    Specialty_code_specialty_seq    SEQUENCE SET     M   SELECT pg_catalog.setval('public."Specialty_code_specialty_seq"', 1, false);
          public          postgres    false    228            .           0    0    Workplace_ID_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."Workplace_ID_seq"', 6, true);
          public          postgres    false    215            g           2606    16706    Address Address_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Address"
    ADD CONSTRAINT "Address_pkey" PRIMARY KEY ("ID");
 B   ALTER TABLE ONLY public."Address" DROP CONSTRAINT "Address_pkey";
       public            postgres    false    231            X           2606    16579 3   EmploymentStatus ChronologyGraduatesJobChanges_pkey 
   CONSTRAINT     w   ALTER TABLE ONLY public."EmploymentStatus"
    ADD CONSTRAINT "ChronologyGraduatesJobChanges_pkey" PRIMARY KEY ("ID");
 a   ALTER TABLE ONLY public."EmploymentStatus" DROP CONSTRAINT "ChronologyGraduatesJobChanges_pkey";
       public            postgres    false    218            V           2606    16572    Workplace Employers_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public."Workplace"
    ADD CONSTRAINT "Employers_pkey" PRIMARY KEY ("ID");
 F   ALTER TABLE ONLY public."Workplace" DROP CONSTRAINT "Employers_pkey";
       public            postgres    false    216            [           2606    16592 $   GraduateStudent GraduateStudent_pkey 
   CONSTRAINT     h   ALTER TABLE ONLY public."GraduateStudent"
    ADD CONSTRAINT "GraduateStudent_pkey" PRIMARY KEY ("ID");
 R   ALTER TABLE ONLY public."GraduateStudent" DROP CONSTRAINT "GraduateStudent_pkey";
       public            postgres    false    222            _           2606    16603    Jobs Jobs_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public."Jobs"
    ADD CONSTRAINT "Jobs_pkey" PRIMARY KEY ("ID");
 <   ALTER TABLE ONLY public."Jobs" DROP CONSTRAINT "Jobs_pkey";
       public            postgres    false    225            c           2606    16612 $   MilitaryService MilitaryService_pkey 
   CONSTRAINT     h   ALTER TABLE ONLY public."MilitaryService"
    ADD CONSTRAINT "MilitaryService_pkey" PRIMARY KEY ("ID");
 R   ALTER TABLE ONLY public."MilitaryService" DROP CONSTRAINT "MilitaryService_pkey";
       public            postgres    false    227            i           2606    16756 "   SelfEmployment SelfEmployment_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public."SelfEmployment"
    ADD CONSTRAINT "SelfEmployment_pkey" PRIMARY KEY ("ID");
 P   ALTER TABLE ONLY public."SelfEmployment" DROP CONSTRAINT "SelfEmployment_pkey";
       public            postgres    false    233            e           2606    16692    Specialty Specialty_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public."Specialty"
    ADD CONSTRAINT "Specialty_pkey" PRIMARY KEY (code_specialty);
 F   ALTER TABLE ONLY public."Specialty" DROP CONSTRAINT "Specialty_pkey";
       public            postgres    false    229            \           1259    16650    fki_ID_addres    INDEX     a   CREATE INDEX "fki_ID_addres" ON public."GraduateStudent" USING btree ("ID_residential_address");
 #   DROP INDEX public."fki_ID_addres";
       public            postgres    false    222            ]           1259    16656    fki_ID_specialty    INDEX     Z   CREATE INDEX "fki_ID_specialty" ON public."GraduateStudent" USING btree (code_specialty);
 &   DROP INDEX public."fki_ID_specialty";
       public            postgres    false    222            `           1259    16662    fki_ID_workplace    INDEX     O   CREATE INDEX "fki_ID_workplace" ON public."Jobs" USING btree ("ID_workplace");
 &   DROP INDEX public."fki_ID_workplace";
       public            postgres    false    225            a           1259    16668 
   fki_status    INDEX     D   CREATE INDEX fki_status ON public."Jobs" USING btree ("ID_status");
    DROP INDEX public.fki_status;
       public            postgres    false    225            Y           1259    16644    fki_student_employstatus    INDEX     _   CREATE INDEX fki_student_employstatus ON public."EmploymentStatus" USING btree ("ID_student");
 ,   DROP INDEX public.fki_student_employstatus;
       public            postgres    false    218            k           2606    16792    GraduateStudent address_student    FK CONSTRAINT     �   ALTER TABLE ONLY public."GraduateStudent"
    ADD CONSTRAINT address_student FOREIGN KEY ("ID_residential_address") REFERENCES public."Address"("ID") NOT VALID;
 K   ALTER TABLE ONLY public."GraduateStudent" DROP CONSTRAINT address_student;
       public          postgres    false    231    222    4711            p           2606    16817    SelfEmployment self_status    FK CONSTRAINT     �   ALTER TABLE ONLY public."SelfEmployment"
    ADD CONSTRAINT self_status FOREIGN KEY ("ID_status") REFERENCES public."EmploymentStatus"("ID") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;
 F   ALTER TABLE ONLY public."SelfEmployment" DROP CONSTRAINT self_status;
       public          postgres    false    4696    233    218            l           2606    16782 !   GraduateStudent specialty_student    FK CONSTRAINT     �   ALTER TABLE ONLY public."GraduateStudent"
    ADD CONSTRAINT specialty_student FOREIGN KEY (code_specialty) REFERENCES public."Specialty"(code_specialty) NOT VALID;
 M   ALTER TABLE ONLY public."GraduateStudent" DROP CONSTRAINT specialty_student;
       public          postgres    false    229    222    4709            m           2606    16802    Jobs status_job    FK CONSTRAINT     �   ALTER TABLE ONLY public."Jobs"
    ADD CONSTRAINT status_job FOREIGN KEY ("ID_status") REFERENCES public."EmploymentStatus"("ID") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;
 ;   ALTER TABLE ONLY public."Jobs" DROP CONSTRAINT status_job;
       public          postgres    false    218    4696    225            o           2606    16812    MilitaryService status_military    FK CONSTRAINT     �   ALTER TABLE ONLY public."MilitaryService"
    ADD CONSTRAINT status_military FOREIGN KEY ("ID_status") REFERENCES public."EmploymentStatus"("ID") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;
 K   ALTER TABLE ONLY public."MilitaryService" DROP CONSTRAINT status_military;
       public          postgres    false    218    4696    227            j           2606    16797 %   EmploymentStatus student_employstatus    FK CONSTRAINT     �   ALTER TABLE ONLY public."EmploymentStatus"
    ADD CONSTRAINT student_employstatus FOREIGN KEY ("ID_student") REFERENCES public."GraduateStudent"("ID") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;
 Q   ALTER TABLE ONLY public."EmploymentStatus" DROP CONSTRAINT student_employstatus;
       public          postgres    false    218    4699    222            n           2606    16807    Jobs workplace_job    FK CONSTRAINT     �   ALTER TABLE ONLY public."Jobs"
    ADD CONSTRAINT workplace_job FOREIGN KEY ("ID_workplace") REFERENCES public."Workplace"("ID") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;
 >   ALTER TABLE ONLY public."Jobs" DROP CONSTRAINT workplace_job;
       public          postgres    false    216    225    4694               y   x�m��	�@EϳUlB�،�d�"h)A�k�X���G<�00��<��T�V$��N�_D�?�z�Yc���3+a�B�?6��1d�����FL^�)d>��T��T��p�� �*h3         /   x�3��4��4202�50�52��paÅ��]l�[/6q��qqq r         �   x�%���@D�*�����z�,!&�N��m�ia�#Vv�F����p�V:�rG���O�+\�Q��A��ז� y�`�[	_i��̤�H��`��A�;P�BL���C!O�;]��r�&�{�2a�33���qg��S8P`      
   -   x�3�4��4㼰��/6 ɍ�]l��~aǅ]�i\1z\\\ `n%            x������ � �            x������ � �         �   x���K�@D��)8�A\q�����=��!L�W���5&Ƹ0q1IwOu�KG�.=\1J+1h9��b�,G�K#��h0H�����#=ߝr���z����XǬ��>*��Ol�E�J�����I��)):hǇZr9;j򙙼�bq}��r�S��-7b�5��XT�hZ;i>.h�S0�Қ(�K�R�7J��L+"         �   x�MK�0\��h8 �|*���ư�h���x�-iPz�y7b`���̼��
7<0`0�s%x��3"~���djL����Ph���V�OO0xI�/FZNp��ʴ��.ˋ��}uPl��"�=�-��Րx�Э���c��^ W?^]     