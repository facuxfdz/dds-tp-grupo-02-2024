import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { parseJwt } from "@utils/decode_jwt";

import { RootState } from '../store';

interface User {
    id?: string;
    name?: string;
    email?: string;
    profile_picture?: string;
    // Add other fields as necessary
}

interface UserState {
    user: User | null;
}

const initialState: UserState = {
    user: null,
};

const userSlice = createSlice({
    name: 'user',
    initialState,
    reducers: {
        setUser: (state, action: PayloadAction<User>) => {
            state.user = action.payload;
        },
        clearUser: (state) => {
            state.user = null;
        },
    },
});

export const selectUser = (state: RootState) => state.user.user;

export const { setUser, clearUser } = userSlice.actions;
export default userSlice.reducer;
