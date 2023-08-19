// @ts-nocheck
import React from 'react'
import {
    makeStyles,
} from "@material-ui/core";

const useStyles = makeStyles({
    arrowIcon: {

    }
});

export default function RightArrow() {
    const classes = useStyles();
  return (
    <img alt="right arrow" src={require('../assets/right-arrow.png')} height="60px" width="80px"></img>
  )
}
