import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import React from 'react';
//import "react-Navigation";

import Main from './src/Pages/Main';
import Login from './src/Pages/Login';

const AuthStack = createStackNavigator();

export default function Stack(){
  return(
    <NavigationContainer>
      <AuthStack.Navigator
        headerMode = 'none'
      >
        <AuthStack.Screen name = 'Login' component={Login} />
        <AuthStack.Screen name = 'Main' component ={Main}/>
      </AuthStack.Navigator>
    </NavigationContainer>
  )
}
