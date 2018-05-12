'use strict';
import React, { Component } from 'react';
import { StyleSheet, Text, View } from 'react-native';
import { createStackNavigator } from 'react-navigation';
import SearchPage from './SearchPage';
import SearchResults from './SearchResults';
import PlantView from './PlantView';

const App = createStackNavigator({
  Home: { screen: SearchPage },
  Results: { screen: SearchResults },
  View: {screen: PlantView },
});

export default App;

