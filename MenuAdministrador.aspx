<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Proyecto_2.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/StyleMenuAdmin.css" rel="stylesheet" />
    <title>Menú Principal</title>
</head>
<body>
    <input type="checkbox" id="menu-toggle" class="main-navigation-toggle" />
    <label for="menu-toggle">
        <svg class="icon--menu-toggle" viewBox="0 0 100 100">
            <g class="icon-group">
                <path class="icon--menu" d="M10 30h80v10H10zm0 20h80v10H10zm0 20h80v10H10z"/>
                <path class="icon--close" d="M30 30l40 40M70 30l-40 40"/>
            </g>
        </svg>
    </label>

    <nav class="main-navigation">
        <button type="button" class="button__submit" onclick="window.location.href='Administrador/Expediente.aspx';">Expediente</button>
        <button type="button" class="button__submit" onclick="window.location.href='Administrador/Acceso.aspx';">Accesos</button>
        <button type="button" class="button__submit" onclick="window.location.href='Administrador/Materias.aspx';">Materias</button>
        <button type="button" class="button__submit" onclick="window.location.href='Administrador/Matriculas.aspx';">Matriculas</button>
        <button type="button" class="button__submit" onclick="window.location.href='Login.aspx';">Regresar</button>
    </nav>
    <div class="main-content">
        <h1>Bienvenido a la Universidad Británica</h1>
        <img src="imagen/shield-college-university-logo-free-vector.jpg" class="hero-image" alt="Logo de la Universidad Británica" />
        <p>Administra los modulos de expediente estudiantil, materias y matriculas </p>

    </div>
    <div class="contact-box">
    <h2>Contacto y Redes Sociales</h2>
    <p><strong>Teléfono:</strong> +123 456 789</p>
    <p><strong>Correo Electrónico:</strong> contacto@universidadbritanica.edu</p>
    <p><strong>Dirección:</strong> Calle Universidad, 123, Ciudad, País</p>
    <p>Síguenos en nuestras redes sociales:</p>
    <div class="social-media">
        <a href="https://facebook.com/universidadbritanica" target="_blank" title="Facebook">
            <svg width="24" height="24" viewBox="0 0 24 24"><path d="M22 0H2C0.9 0 0 0.9 0 2v20c0 1.1 0.9 2 2 2h11.2v-9.2H9.4V12h3.8v-2.6c0-3.8 2.3-5.8 5.7-5.8 1.6 0 3.1 0.1 3.5 0.1v4.1l-2.4 0c-1.9 0-2.3 0.9-2.3 2.3v3h4.6l-0.6 4.8H17v9.2H22c1.1 0 2-0.9 2-2V2c0-1.1-0.9-2-2-2z"/></svg>
        </a>
        <a href="https://twitter.com/universidadbritanica" target="_blank" title="Twitter">
            <svg width="24" height="24" viewBox="0 0 24 24"><path d="M22.46 6.003c-0.76 0.34-1.58 0.57-2.44 0.68 0.88-0.53 1.56-1.38 1.88-2.39-0.82 0.49-1.72 0.85-2.68 1.05-0.77-0.82-1.87-1.33-3.09-1.33-2.34 0-4.24 1.9-4.24 4.24 0 0.33 0.03 0.65 0.1 0.96-3.52-0.18-6.65-1.86-8.75-4.42-0.36 0.62-0.57 1.34-0.57 2.11 0 1.46 0.74 2.74 1.87 3.49-0.69-0.02-1.34-0.21-1.91-0.52v0.05c0 2.03 1.44 3.73 3.34 4.11-0.35 0.09-0.72 0.13-1.09 0.13-0.27 0-0.53-0.03-0.79-0.07 0.53 1.66 2.06 2.87 3.88 2.91-1.42 1.11-3.21 1.77-5.15 1.77-0.33 0-0.66-0.02-0.99-0.06 1.84 1.18 4.02 1.88 6.37 1.88 7.64 0 11.83-6.33 11.83-11.83 0-0.18-0.01-0.35-0.02-0.53 0.81-0.59 1.51-1.33 2.07-2.17z"/></svg>
        </a>
        <a href="https://instagram.com/universidadbritanica" target="_blank" title="Instagram">
            <svg width="24" height="24" viewBox="0 0 24 24"><path d="M12 2.2c3.12 0 3.48 0.01 4.72 0.07 1.24 0.06 2.18 0.29 2.84 0.61 0.66 0.31 1.2 0.76 1.7 1.36 0.5 0.5 1.05 1.03 1.36 1.69 0.32 0.66 0.55 1.6 0.61 2.84 0.06 1.24 0.07 1.6 0.07 4.72s-0.01 3.48-0.07 4.72c-0.06 1.24-0.29 2.18-0.61 2.84-0.31 0.66-0.76 1.2-1.36 1.7-0.5 0.5-1.03 1.05-1.69 1.36-0.66 0.32-1.6 0.55-2.84 0.61-1.24 0.06-1.6 0.07-4.72 0.07s-3.48-0.01-4.72-0.07c-1.24-0.06-2.18-0.29-2.84-0.61-0.66-0.31-1.2-0.76-1.7-1.36-0.5-0.5-1.05-1.03-1.36-1.69-0.32-0.66-0.55-1.6-0.61-2.84-0.06-1.24-0.07-1.6-0.07-4.72s0.01-3.48 0.07-4.72c0.06-1.24 0.29-2.18 0.61-2.84 0.31-0.66 0.76-1.2 1.36-1.7 0.5-0.5 1.03-1.05 1.69-1.36 0.66-0.32 1.6-0.55 2.84-0.61 1.24-0.06 1.6-0.07 4.72-0.07zM12 0c-3.14 0-3.52 0.01-4.76 0.07-1.24 0.06-2.34 0.29-3.22 0.68-0.88 0.38-1.65 0.91-2.31 1.57-0.66 0.66-1.19 1.43-1.57 2.31-0.39 0.88-0.62 1.98-0.68 3.22-0.06 1.24-0.07 1.62-0.07 4.76s0.01 3.52 0.07 4.76c0.06 1.24 0.29 2.34 0.68 3.22 0.38 0.88 0.91 1.65 1.57 2.31 0.66 0.66 1.43 1.19 2.31 1.57 0.88 0.39 1.98 0.62 3.22 0.68 1.24 0.06 1.62 0.07 4.76 0.07s3.52-0.01 4.76-0.07c1.24-0.06 2.34-0.29 3.22-0.68 0.88-0.38 1.65-0.91 2.31-1.57 0.66-0.66 1.19-1.43 1.57-2.31 0.39-0.88 0.62-1.98 0.68-3.22 0.06-1.24 0.07-1.62 0.07-4.76s-0.01-3.52-0.07-4.76c-0.06-1.24-0.29-2.34-0.68-3.22-0.38-0.88-0.91-1.65-1.57-2.31-0.66-0.66-1.43-1.19-2.31-1.57-0.88-0.39-1.98-0.62-3.22-0.68-1.24-0.06-1.62-0.07-4.76-0.07zM12 5.84c-3.4 0-6.16 2.76-6.16 6.16 0 3.4 2.76 6.16 6.16 6.16 3.4 0 6.16-2.76 6.16-6.16 0-3.4-2.76-6.16-6.16-6.16zM12 16.16c-2.51 0-4.56-2.05-4.56-4.56 0-2.51 2.05-4.56 4.56-4.56 2.51 0 4.56 2.05 4.56 4.56 0 2.51-2.05 4.56-4.56 4.56z"/></svg>
        </a>
    </div>
</div>

</body>
</html>
