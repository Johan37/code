'use strict';

import React, { Component } from 'react'
import {
  StyleSheet,
  Image,
  View,
  TouchableHighlight,
  Text,
} from 'react-native';


export default class PlantView extends Component {
  static navigationOptions = {
    title: 'Plant',
  };

  render() {
    const { params } = this.props.navigation.state;
    const price = params.plantItem.price_formatted.split(' ')[0];
    console.log(params.plantItem);
    return (
      <View style={styles.container}>
        <Image style={styles.thumb} source={{ uri: params.plantItem.img_url }} />
        <Text style={styles.price}>
          {price}
        </Text>
        <Text style={styles.title}>
          {params.plantItem.title}
        </Text>
        <Text style={styles.description}>
          {params.plantItem.summary}
        </Text>
      </View>
    );
  }
}

const styles = StyleSheet.create({
  description: {
    marginBottom: 10,
    fontSize: 18,
    textAlign: 'center',
    color: '#656565'
  },
  container: {
    padding: 30,
    marginTop: 15,
    alignItems: 'center'
  },
  title: {
    marginBottom: 15,
    fontSize: 22,
    fontWeight: 'bold',
    textAlign: 'center',
    color: '#656565'
  },
  thumb: {
    width: 400,
    height: 300,
  },
  price: {
    fontSize: 25,
    fontWeight: 'bold',
    color: '#48BBEC'
  },
});
