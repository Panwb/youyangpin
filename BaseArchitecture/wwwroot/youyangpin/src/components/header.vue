<template>
  <div class="header">
      <!--header start--->
       <div class="optbox">
          <div class="wd1200">      
        <span class="loginbtn">请登录</span>
        <span>免费注册</span>
          </div>
         </el-header>
      </div>
      <div class="wd1200 searchbox">
        <el-row>
        <el-col :span="8"><div class="grid-content bg-purple"> <img src="../assets/images/logo.png" class="logo"></div></el-col>
        <el-col :span="16">
         <div class="grid-content bg-purple-light seabox">
           <el-input placeholder="关键词搜索" prefix-icon="el-icon-search"></el-input>
           <el-button class="sea-btn">搜索</el-button>
         </div>
        </el-col>
      </el-row>
      </div>
      <div class="navbox">
      <el-header>
         <div class="wd1200">
          <el-menu :default-active="activeIndex"  class="el-menu-demo" mode="horizontal" @select="handleSelect" background-color="#261f1e" text-color="#fff" active-text-color="#f9513b">
          <el-menu-item index="1">首页</el-menu-item>
          <el-menu-item index="2">日常产品</el-menu-item>
          <el-menu-item index="3">秒杀产品</el-menu-item>
          <el-menu-item index="4">新款产品</el-menu-item>
          <el-menu-item index="5">清仓产品</el-menu-item>
          <el-menu-item index="6">高端产品</el-menu-item>
        </el-menu>
       </div>
      </el-header>
    </div>
    <!--header end--->
  </div>
</template>

<script>
  export default {
    name: 'myheader',
    data() {
      return {
        activeIndex: '1',
      };
    },
    methods: {
      handleSelect(key, keyPath) {
        console.log(key, keyPath);
      }
    }
  }
</script>
