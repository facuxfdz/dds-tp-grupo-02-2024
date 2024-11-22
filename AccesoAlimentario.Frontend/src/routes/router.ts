export const loginRoute = () => {
    return '/login';
}

export const inicioRoute = () => {
    return '/admin/inicio';
}

export const premiosRoute = () => {
    return '/admin/premios';
}

export const contribucionesRoute = () => {
    return '/admin/contribuciones';
}

export const personaVulnerableRegistroRoute = () => {
    return '/admin/personas-vulnerables/registro';
}

export const heladerasRoute = () => {
    return '/admin/heladeras';
}

export const heladeraViandasRoute = (heladeraId: string) => {
    return `/admin/heladeras/${heladeraId}/viandas`;
}

export const heladeraIncidentesRoute = (heladeraId: string) => {
    return `/admin/heladeras/${heladeraId}/incidentes`;
}

export const suscripcionesRoute = () => {
    return '/admin/suscripciones';
}

export const colaboradoresRegistroRoute = () => {
    return '/admin/colaboradores/registro';
}

export const colaboradoresImportarRoute = () => {
    return '/admin/colaboradores/importar';
}

export const reportarIncidenciaRoute = () => {
    return '/admin/reportar-incidencia';
}

export const reportesRoute = () => {
    return '/admin/reportes';
}

export const perfilRoute = () => {
    return '/admin/perfil';
}