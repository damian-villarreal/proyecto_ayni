use Proyecto_Ayni

insert into Usuario (NombreUsuario, CantidadFavoresRealizados, CantidadFavoresRecibidos, Password, Email, PrivateKey, Address, Words)
values ('juanSanchez', 0, 0, 'Usuario12345', 'juansanchez@usuario.com.ar','0x8b5932cbaee06da081ebe1ca2923d43f926a53c8901a8103d1b3296678a98671','0x1918532dC3210021ED03Cd19BF7aB71112F6ccC0','first gesture basic engine black attitude chapter donkey elbow diet lion congress'),
('CosmeFulanito', 2, 5, 'Usuario12345', 'cosmefulanito@usuario.com.ar', '0xa8be7a49647c6f7c5d33b26581c01cb5e568c915dc095cd087837136e0db821b', '0x6097e58411bf53493599C1E5867e9b291d8C6300', 'planet stone unfair erupt broccoli display economy idle myth wire cement give'),
('LaloLanda', 6, 8, 'Usuario12345', 'lalolanda@usuario.com.ar', '0x553fc059e3bc8a3c9986b6247636dc8c3052af73e1a01cbc42dbcd8661517bd9', '0xd3C018001F070b62539176aa6b151350A2C07fa2', 'expand recall devote envelope report air habit type maze shrug crane step'),
('TroyMcClure', 2, 5, 'Usuario12345', 'troymcclure@usuario.com','0xdc56df262a4890095efb8593fd5ed4743232b81bc7b8e918051afec8eab21689','0xD302a55B0d7CDc1fA39c771e3115F5e31a26747f', 'street grow access remove message dolphin idea suit copper frog siren feature'),
('LionelHutz', 4, 1, 'Usuario12345', 'lionelhutz@usuario.com','0x1ada60ef54ec5158942dedd3ad609ca52fb0f14dbdd390d2fde8279762e215ed', '0xA396e3e8d7F673B14cfB1420FA5d3DFcE33d6EEd', 'lab upgrade release electric tent happy south feature only fruit frog shock')

insert into TipoPublicacion (Descripcion)
values ('pedido'),('Ofrecido')

insert into Categoria (Descripcion)
values ('tareas hogareñas'),
('prestamo de herramientas'),
('consejos'),
('cuidado de personas'),
('asesoramiento'),
('otros')

insert into EstadoPublicacion (Descripcion)
values ('activa'),('interrumpida'),('finalizada')

insert into EstadoTransaccion (Descripcion)
values ('en proceso'),('cancelada'), ('finalizada')

insert into Publicacion (Titulo, idUsuario, Valor, idTipoPublicacion, Descripcion, Fecha_publicacion, Fecha_inicio, Fecha_fin, idEstadoPublicacion, idCategoria)
values ('necesito subir un sillon 10 pisos por escalera', 1, 50, 1, 'Soy una señora mayor que necesita ayuda con una mudanza', '20190923','20190923','20190923', 1, 1)
