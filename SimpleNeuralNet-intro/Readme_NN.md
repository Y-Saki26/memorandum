# SimpleNeuralNet-intro

PyTorchでニューラルネットを組んで学習・評価ができるまで

## 環境構築

Windows11 / Anaconda で構築．

PyTorch用環境を作成，モジュールのインストール．
Jupyter Notebookの拡張機能の利用のため nbextensions と autopep8 を導入．
PyTorch関連は [PyTorch公式](https://pytorch.org/get-started/locally/) でバージョンを確認(以下は Stable(1.12.1), Windows, Conda, Python, CUDA 11.3 を選択)．

```sh
conda create -n torch
conda activate torch
conda install python jupyter numpy pandas matplotlib scipy
conda install pytorch torchvision torchaudio cudatoolkit=11.3 -c pytorch
conda install -c conda-forge jupyter_contrib_nbextensions autopep8 scikit-learn optuna skorch pytorch-lightning torchinfo
```

`torch_env_bak.yml` に書き出したので以下で同じ環境が作れるはず．

```sh
conda env create -f=env_bak.yml
```

## 実行

2値分類問題をニューラルネットで学習し，optunaでハイパーパラメータの最適化をする．
実行コードは `skorch-test.ipynb` ．
