import {combineReducers, configureStore} from "@reduxjs/toolkit";
import {persistStore, persistReducer} from 'redux-persist';
import storageEngine from './storageEngine';

import themeSlice from "@redux/features/themeSlice";
import customizationSlice from "@redux/features/customizationSlice";
import userSlice from "@redux/features/userSlice";

import {colaboradoresApi} from "@redux/services/colaboradoresApi";
import {contribucionesApi} from "@redux/services/contribucionesApi";
import {reportesApi} from "@redux/services/reportesApi";
import {serviciosApi} from "@redux/services/serviciosApi";
import {tecnicosApi} from "@redux/services/tecnicosApi";
import {heladerasApi} from "@redux/services/heladerasApi";
import {premiosApi} from "@redux/services/premiosApi";
import {authApi} from "@redux/services/authApi";

const persistConfig = {
    key: 'accesoAlimentario',
    storage: storageEngine,
    whitelist: ['customization', 'theme', 'user'],
    timeout: 1000,
};

const rootReducer = combineReducers({
    // Slices
    theme: themeSlice,
    customization: customizationSlice,
    user: userSlice,

    // Services
    [colaboradoresApi.reducerPath]: colaboradoresApi.reducer,
    [contribucionesApi.reducerPath]: contribucionesApi.reducer,
    [reportesApi.reducerPath]: reportesApi.reducer,
    [serviciosApi.reducerPath]: serviciosApi.reducer,
    [tecnicosApi.reducerPath]: tecnicosApi.reducer,
    [heladerasApi.reducerPath]: heladerasApi.reducer,
    [premiosApi.reducerPath]: premiosApi.reducer,
    [authApi.reducerPath]: authApi.reducer,
});

const persistedReducer = persistReducer(persistConfig, rootReducer);

export const store = configureStore({
    reducer: persistedReducer,
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware({
                serializableCheck: {
                    ignoredActions: ['persist/PERSIST'],
                    ignoredPaths: ['register'],
                },
            },
        )
            .concat(
                colaboradoresApi.middleware,
                contribucionesApi.middleware,
                reportesApi.middleware,
                serviciosApi.middleware,
                tecnicosApi.middleware,
                heladerasApi.middleware,
                premiosApi.middleware,
                authApi.middleware
            ),
});

export const persistor = persistStore(store);

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
