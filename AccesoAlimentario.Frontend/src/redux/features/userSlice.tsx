import {createSlice, PayloadAction} from '@reduxjs/toolkit';
import {ContribucionesTipo} from "@models/enums/contribucionesTipo";

export interface User {
    // Si es colaborador, el id es el del colaborador
    // Si es tecnico, el id es el del tecnico
    colaboradorId: string;
    tecnicoId: string;

    name: string;
    profile_picture: string;

    contribucionesPreferidas: ContribucionesTipo[];
    tarjetaColaboracionId: string;
    personaTipo: 'Humana' | 'Juridica';
    isAdmin?: boolean;
}

const initialState: User = {
    colaboradorId: '',
    tecnicoId: '',

    name: '',
    profile_picture: '',

    contribucionesPreferidas: [],
    tarjetaColaboracionId: '',
    personaTipo: 'Humana',
    isAdmin: false,
};

const userSlice = createSlice({
    name: 'user',
    initialState,
    reducers: {
        setUser: (state, action: PayloadAction<User>) => {
            state.colaboradorId = action.payload.colaboradorId;
            state.tecnicoId = action.payload.tecnicoId;

            state.name = action.payload.name;
            state.profile_picture = action.payload.profile_picture;

            state.contribucionesPreferidas = action.payload.contribucionesPreferidas;
            state.tarjetaColaboracionId = action.payload.tarjetaColaboracionId;
            state.personaTipo = action.payload.personaTipo;
            state.isAdmin = action.payload.isAdmin;
        },
        clearUser: (state) => {
            state.colaboradorId = '';
            state.tecnicoId = '';

            state.name = '';
            state.profile_picture = '';

            state.contribucionesPreferidas = [];
            state.tarjetaColaboracionId = '';
            state.personaTipo = 'Humana';
            state.isAdmin = false;
        },
        setUserName: (state, action: PayloadAction<string>) => {
            state.name = action.payload;
        },
        setUserTarjetaColaboracionId: (state, action: PayloadAction<string>) => {
            state.tarjetaColaboracionId = action.payload;
        }
    },
});

export const {
    setUser, clearUser, setUserName,
    setUserTarjetaColaboracionId
} = userSlice.actions;
export default userSlice.reducer;
