import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import React from 'react';
//import "react-Navigation";

import Main from './src/Screens/main';
import Login from './src/Screens/login';

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
