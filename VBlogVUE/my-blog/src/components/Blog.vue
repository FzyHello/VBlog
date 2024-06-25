<template>
  <div class="blog">
    <el-row :span="24" class="blog-row">
      <el-col :span="6">1</el-col>
      <el-col :span="12">
        <el-row :span="24" class="blog-row">
          <el-col :span="6">
            <div class="blog-info">
              <div class="blog-info-top">
                <el-row>
                  <el-col :span="8">
                    <el-avatar :size="45" :src="circleUrl"
                  /></el-col>
                  <el-col :span="16">
                    <div class="blog-info-top-nameBox">
                      <div class="blog-info-top-nameBox-name">Aimer</div>
                      <div class="blog-info-top-nameBox-role">个人博客</div>
                    </div></el-col
                  >
                </el-row>
              </div>
            </div>
          </el-col>
          <el-col :span="18">
            <div class="blog-content">
              <el-tabs
                v-model="activeName"
                class="demo-tabs"
                @tab-click="handleClick"
              >
                <el-tab-pane label="近期发布" name="first"
                  >近期发布</el-tab-pane
                >
                <el-tab-pane label="分类" name="second">分类</el-tab-pane>
                <el-tab-pane label="标签" name="third">标签</el-tab-pane>
                <el-tab-pane label="归档" name="fourth">归档</el-tab-pane>
              </el-tabs>
            </div>
          </el-col>
        </el-row>
      </el-col>
      <el-col :span="6">3</el-col>
    </el-row>
  </div>
</template>

<script setup name="Blog">
import { ref } from "vue";

const activeName = ref("first");
const circleUrl = ref("");

function handleClick(tab) {
  console.log(tab);
}
</script>

<style lang="scss" scoped>
.blog {
  height: 100%;
  display: flex;
  padding: 10px;
  flex-direction: column;
  background-color: #f2f3f5;

  &-row {
    flex: 1;
    height: 100%;
  }

  &-info {
    height: 100%;
    padding: 20px 10px;
    background-image: linear-gradient(#e9e9e5, #b9bcb3 100%);
    backdrop-filter: blur(10px) brightness(90%);
    background-color: rgba(255, 255, 255, 0.5);
    border-radius: 10px;
    &-top {
      height: 50px;
      &-nameBox {
        height: 50px;
        display: flex;
        flex-direction: column;
        &-name {
          font-size: 18px;
          font-weight: 700;
        }
        &-role {
          font-size: 12px;
          color: #4d4d4c;
        }
      }
    }
  }

  &-content {
    height: 100%;
    padding: 0 30px;
  }
}
</style>
