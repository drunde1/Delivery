PGDMP                  	    |         
   deliverydb    16.3 (Debian 16.3-1.pgdg120+1)    16.4     !           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            "           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            #           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            $           1262    16384 
   deliverydb    DATABASE     u   CREATE DATABASE deliverydb WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'en_US.utf8';
    DROP DATABASE deliverydb;
                postgres    false            �            1259    16401    Orders    TABLE     �   CREATE TABLE public."Orders" (
    "Id" uuid NOT NULL,
    "Weight" double precision NOT NULL,
    "District" text NOT NULL,
    "DeliveryTime" timestamp with time zone NOT NULL
);
    DROP TABLE public."Orders";
       public         heap    postgres    false                      0    16401    Orders 
   TABLE DATA           N   COPY public."Orders" ("Id", "Weight", "District", "DeliveryTime") FROM stdin;
    public          postgres    false    217   �       �           2606    16407    Orders PK_Orders 
   CONSTRAINT     T   ALTER TABLE ONLY public."Orders"
    ADD CONSTRAINT "PK_Orders" PRIMARY KEY ("Id");
 >   ALTER TABLE ONLY public."Orders" DROP CONSTRAINT "PK_Orders";
       public            postgres    false    217                 x��WM�&K\ל�=�i;��,l���� !�'n���p�onDT�[�'4�b�݋VG���5b�D��M�g�6�&i>s�Z�̇�|��������o_��7��>��q$NJ�R~d�1���̟2����U�%;`�S�Ik١�����r���q�TJ�1�x��DI�z5��Z��A���_}b7��o�榭5�f-T�7ґ�5ϻ�tXV��ڷ'�Bꥒ�e��1,�nMK���η��Jwc���)ܙ����������^`��ifrN�ܖS-k��f�Rrh��a�.��:Ƭ�ta��`�u�U[����zM�����c�i���`۠8�iFղW:��ثrK5-�~WNX7���lIT)/ڏbz������}`��x�{&�
�X-��uzn�Ὓd=���	t?�_^�z��{�邝xU����H�E���7�d>��r|���U�Q6���Y@vƤ�v�&���*?���t5��i�)�3,2��rtH��-���Ád�:d�L*�\Oq�(p͖Fj��N�{
}5_K����a>�0�p!]vOs*G{�W�,�d�0��C��T��i��|o`����5�T&#QD �27��3���s��}%?|G�����ڨ�r���B���6�H���É�5;�����B��	Ӕ1��ŘtϹ��ޛ�͋��U�����ba�u�&e��u0�߿�����������sح��W%h��CϲDf��4�gv<��[��x�J�q�;���jSb��vd�%���o۹���t7�>��c�9[�Z����\��6����t�!�^��?�ux�2�o�,;q�MH|H�VHl�B�KQ_�5�C���]�
+�Ж	�İC��0c缭������K5����3��� VC��E{d�m���C?�v�z��&�lw��
>�"`h�{�R���*�۱����ֆAF1�I�]:��!+��ѳ�ح�\K���s"�z�S4��p������h�^��}���i�P ���K��|����G~o��]�D�Ŏ�HE���}")���ߞ _ׅZNR���M��W�"X�̹���!_�0�%�ފ�=��g���`.VP+P�~��=rNo���@��B��}�}Cq�D/I����x�Z"T�4P1O�ɶbΨ�ܙc���V&f�3E ȑ�i" Q��!}2M�%���L��s5�(@� ���z��)���8 _ռf�.2�<;
Ώ���{2_gi��X���)�ZGcK]�y$AX(�{��g?����y�r��H#g��5	�˱�����:�n��>�1�N��rA^V>��
��:]����Ҽ�}�&���JS�8�K�G��[Z���-�51m�V�W*�pvn�bW�Bou���L�mkD�e��A+{:�Zej��bX���~>��:�S0��@��n�fh��)Z��Ձ�s���޼��O�fXq&@�-�B���K��K?>.���^ɢ��A�2O؁#����PS;4F?� ��
��3��H�}�SA���4l+�N�P��t�O��>}��_韲
     