package com.example.zenly;

import android.app.Application;

import com.yandex.mapkit.MapKitFactory;
public class MainApplication extends Application {
    private final String MAPKIT_API_KEY = "dcbbd772-8e58-48cc-b865-d9ae51c6ceea";

    @Override
    public void onCreate() {
        super.onCreate();
        // Set the api key before calling initialize on MapKitFactory.
        MapKitFactory.setApiKey(MAPKIT_API_KEY);
    }
}
