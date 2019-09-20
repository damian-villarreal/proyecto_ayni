use Proyecto_Ayni

insert into Usuario (NombreUsuario, CantidadFavoresRealizados, CantidadFavoresRecibidos, Password, Email)
values ('juanSanchez', 0, 0, 'Usuario12345', 'juansanchez@usuario.com.ar'),
('CosmeFulanito', 2, 5, 'Usuario12345', 'cosmefulanito@usuario.com.ar'),
('LaloLanda', 6, 8, 'Usuario12345', 'lalolanda@usuario.com.ar'),
('TroyMcClure', 2, 5, 'Usuario12345', 'troymcclure@usuario.com'),
('LionelHutz', 4, 1, 'Usuario12345', 'lionelhutz@usuario.com')

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
