import React, { Component } from 'react';

export class ListRestaurants extends Component {
    static displayName = ListRestaurants.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

  componentDidMount() {
    this.populateListRestaurantsData();
  }

  static renderForecastsTable(forecasts) {
      return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Date</th>
            <th>Name</th>
            <th>Type</th>
            <th>Place</th>
            <th>Suggested by</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
            <tr key={forecast.restaurantName}>
              <td>{forecast.createdDateString}</td>
              <td>{forecast.restaurantName}</td>
              <td>{forecast.restaurantDescription}</td>
              <td>{forecast.restaurantAddresse}</td>
              <td>{forecast.suggestedBy.userName}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading ? <p><em>Loading...</em></p> : ListRestaurants.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <h1 id="tabelLabel" >List of restaurants</h1>
        {contents}
      </div>
    );
  }

  async populateListRestaurantsData() {
    const response = await fetch('listrestaurants');
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }
}
